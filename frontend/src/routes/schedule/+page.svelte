<script lang="ts">
	import { onMount } from 'svelte';
	import { fetchSchedule, fetchScheduleQuery } from '../../api/schedule';
	import ScheduleTable from '../../components/scheduleTable.svelte';
	import { goto } from '$app/navigation';

	import type { PageData } from './$types'; // Automatically generated from `+page.ts`
	import type { Booking } from '$lib/types';

	export let data: PageData; // Access `week` and `year` from `load()`

	let week = data.week;
	let year = data.year;

	let loading = false;
	let error: string | null = null;

	let scheduleData: any = [];
	let formattedBookings: Booking[];

	if (week == -1 || year == -1) {
		error = 'Error while parsing week/year.';
	}

	function setWeekNumber(date: Date) {
		const newYear = date.getFullYear();
		const firstJan = new Date(year, 0, 1);
		const daysSinceFirstJan = Math.floor(
			(date.getTime() - firstJan.getTime()) / (1000 * 60 * 60 * 24)
		);
		const newWeek = Math.ceil((daysSinceFirstJan + firstJan.getDay() + 1) / 7);
		goto(`?week=${newWeek}&year=${newYear}`);
		updateSchedule();
	}

	function changeWeek(offset: number) {
		const newDate = new Date(year, 0, 1); // Start from January 1st of current year
		newDate.setDate(newDate.getDate() + (week - 1) * 7 + offset * 7); // Adjust by weeks

		// Recalculate the correct year and week number
		year = newDate.getFullYear();
		const firstJan = new Date(year, 0, 1);
		const daysSinceFirstJan = Math.floor(
			(newDate.getTime() - firstJan.getTime()) / (1000 * 60 * 60 * 24)
		);
		week = Math.ceil((daysSinceFirstJan + firstJan.getDay() + 1) / 7);

		goto(`?week=${week}&year=${year}`);
		updateSchedule();
	}

	async function updateSchedule() {
		console.log(year);
		console.log(week);
		loading = true;
		const { data, error: fetchError } = await fetchScheduleQuery(year, week);
		scheduleData = data;
		formattedBookings = scheduleData.map(convertToBooking);
		error = fetchError;
		loading = false;
	}

	function convertToBooking(rawData: any): Booking {
		const startTime = new Date(rawData.startDate);

		return {
			day: startTime.getDay(), // Converts to 0 (Sunday) - 6 (Saturday)
			hour: startTime.getHours(), // Extracts hour from 00:00 to 23:00
			info: `Room: ${rawData.roomId}, User: ${rawData.userId}` // Customize as needed
		};
	}

	onMount(async () => {
		goto(`?week=${week}&year=${year}`);
		updateSchedule();
	});
</script>

{#if loading}
	<p>Loading...</p>
{:else if error}
	<p class="error">{error}</p>
{:else}
	<div class="week-header">
		<button class="button" on:click={() => changeWeek(-1)}>⬅</button>
		Week {week}
		<button class="button" on:click={() => changeWeek(1)}>➡</button>
	</div>
	<ScheduleTable bookings={formattedBookings} />
{/if}

<style>
	.week-header {
		display: flex;
		align-items: center;
		justify-content: space-between;
		font-size: 18px;
		font-weight: bold;
		padding: 5px;
	}
	.error {
		color: red;
	}
</style>
