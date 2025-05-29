<script lang="ts">
	import type { Booking } from '$lib/types';
	import { onMount } from 'svelte';

	export let bookings: Booking[] = [];

	console.log(bookings);

	const daysOfWeek = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];

	let weekGrid: string[][] = Array.from({ length: 7 }, () => Array(24).fill(''));

	function populateGrid() {
		weekGrid = Array.from({ length: 7 }, () => Array(24).fill(''));
		bookings.forEach((booking) => {
			weekGrid[booking.day][booking.hour] = booking.info;
		});
	}

	onMount(() => {
		populateGrid();
	});
</script>

<div class="week-view">
	<div class="day-header"></div>

	<!-- Empty space for hour labels -->
	{#each daysOfWeek as day}
		<div class="day-header">{day}</div>
	{/each}

	{#each Array(24) as _, hIndex}
		<div class="hour-label">{hIndex}:00</div>
		{#each weekGrid as day}
			<div class="hour">{day[hIndex]}</div>
		{/each}
	{/each}
</div>

<style>
	.week-view {
		display: grid;
		grid-template-columns: 80px repeat(7, 1fr);
		gap: 5px;
	}
	.day-header {
		font-weight: bold;
		text-align: center;
		padding: 5px;
		border-bottom: 2px solid #000;
	}
	/* .day {
		display: grid;
		grid-template-rows: repeat(24, 30px);
		border: 1px solid #ccc;
	} */
	.hour-label {
		font-weight: bold;
		text-align: right;
		padding-right: 5px;
		border-right: 2px solid #000;
	}
	.hour {
		border-bottom: 1px solid #ccc;
		padding: 3px;
		font-size: 12px;
		min-height: 30px;
	}
</style>
