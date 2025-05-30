<script lang="ts">
	import { userStore } from '../api/user';
	import type { User } from '../api/user';

	let loggedInUser = $state($userStore);

	userStore.subscribe((value) => {
		loggedInUser = value;
	});

	let { booking = {}, user = {}, room = {}, activity = {} } = $props();

	let startDate = new Date(booking.startDate);
	let endDate = new Date(booking.endDate);
</script>

<div class="booking-card">
	<h2>Booking Details</h2>

	<p><strong>Room#:</strong> {room.roomNumber}</p>

	<p>
		<strong>Activity:</strong>
		{#if Object.keys(activity).length}
			{activity.Name}
		{:else}
			None specified
		{/if}
	</p>

	<p><strong>Booker:</strong> {user.userName}</p>

	<p><strong>Start:</strong>{startDate}</p>
	<p><strong>End:</strong>{endDate}</p>
</div>

{#if loggedInUser}
	<div>Edit Booking</div>
{/if}

<style>
	.booking-card {
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}
</style>
