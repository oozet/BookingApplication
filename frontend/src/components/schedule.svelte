<script lang="ts">
	import { onMount } from 'svelte';
	import { fetchSchedule } from '../api/schedule';

	let scheduleData: any = null;
	type WeekRange = { startDate: Date; endDate: Date };

	let { startDate, endDate }: WeekRange = getCurrentWeek(new Date());

	let loading = false;
	let error: string | null = null;

	function getCurrentWeek(start: Date): { startDate: Date; endDate: Date } {
		const dayOfWeek = start.getDay(); // Sunday = 0, Monday = 1, ..., Saturday = 6

		const daysToSubtract = dayOfWeek === 0 ? 6 : dayOfWeek - 1; // Move to Monday
		const startDate = new Date(start);
		startDate.setDate(start.getDate() - daysToSubtract);
		startDate.setHours(0, 0, 0, 0); // Reset time

		const endDate = new Date(startDate);
		endDate.setDate(startDate.getDate() + 6); // Get Sunday of the same week
		endDate.setHours(23, 59, 59, 999); // Set to end of the day

		return { startDate, endDate };
	}

	async function updateSchedule() {
		loading = true;
		const { data, error: fetchError } = await fetchSchedule(startDate, endDate);
		scheduleData = data;
		error = fetchError;
		loading = false;
	}

	$: if (startDate) {
		updateSchedule();
	}

	onMount(async () => {
		updateSchedule();
	});
</script>

{#if loading}
	<p>Loading...</p>
{:else if error}
	<p class="error">{error}</p>
{:else}
	<input type="date" bind:value={startDate} />
	<!-- <button on:click={updateSchedule} disabled={loading}>Fetch Schedule</button> not needed because of $: reactive statement-->
	<p>Data: {JSON.stringify(scheduleData)}</p>
{/if}

<style>
	.error {
		color: red;
	}
</style>
