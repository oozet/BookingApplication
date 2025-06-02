<script lang="ts">
	import type { PageData } from './$types';
	import { invalidateAll } from '$app/navigation';
	import { BookingApi } from '../../../api/booking';
	import { userStore } from '../../../api/user';

	let { data }: { data: PageData } = $props();
	const roomId: string = data.slug;
	const activities = data.activities;

	
    let user: any;
    $effect: userStore.subscribe(value => user = value);


	let message = $state('');

	let start: string = $state(new Date().toUTCString());
	let end: string = $state(new Date().toUTCString());
	let activity: string | null = $state(null);

	async function createBooking(event: SubmitEvent) {
		const startDate = new Date(start).toISOString();
		console.log(startDate);
		const endDate = new Date(end).toISOString();
		console.log(endDate);
		event.preventDefault();
		message = await BookingApi.Create(startDate, endDate, roomId, user.id, activity);

		invalidateAll();
	}
	
</script>

<div>
	<h3>Create Booking</h3>
	<p>{message}</p>
	{#if !user}
	<p>Must be logged in to book room.</p>
	{:else}
	<form onsubmit={createBooking}>
		<label for="">
			Start Date: <input type="datetime-local" bind:value={start} />
		</label>
		<label for="">
			End Date: <input type="datetime-local" bind:value={end} />
		</label>
		<label for="">
			Activity:
			<select bind:value={activity}>
				<option value={null}>None</option>
				{#each activities as activity}
					<option value={activity.id}>{activity.name}</option>
				{/each}
			</select>
		</label>
		<button type="submit">Create Booking</button>
	</form>
	{/if}
</div>

<style>
</style>
