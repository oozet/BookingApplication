<script lang="ts">
	// We'll fetch this data in th slug page server and then send it
	// as a prop to this component to make the component be more of a component.
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

<style>
	.booking-card {
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}
</style>
