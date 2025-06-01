<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import { BookingApi } from '../../api/booking';
	import { onMount } from 'svelte';
	import { ActivityApi, type Activity } from '../../api/activity';
	import type { PageData } from './$types';

	let { data }: { data: PageData } = $props();
	const roomId: string = data.roomId;

	let activities: Activity[] = $state([]);

	let message = $state('');

	let startDate: Date = $state(new Date());
	let endDate: Date = $state(new Date());
	let activity: string | null = $state(null);

	async function createBooking(event: SubmitEvent) {
		event.preventDefault();
		message = await BookingApi.Create(startDate, endDate, roomId, userId, activity);

		invalidateAll();
	}

	async function getData() {
		activities = await ActivityApi.getAll();
	}

	onMount;
	{
		getData();
	}
</script>

<div class="add-booking-modal">
	<h3>Create Booking</h3>
	<p>{message}</p>
	<form onsubmit={createBooking}>
		<label for="">
			Start Date: <input type="date" bind:value={startDate} />
		</label>
		<label for="">
			End Date: <input type="date" bind:value={endDate} />
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
</div>

<style>
	.add-booking-modal {
		z-index: 100;
		position: fixed;
		top: 15%;
		left: 15%;
		width: 70%;
		height: 70%;
		background-color: #bcc4dbff;
		border: 2px solid rgb(178, 186, 207);
		border-radius: 10px;

		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}

	p {
		text-align: center;
	}

	.add-booking-modal form {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}
</style>
