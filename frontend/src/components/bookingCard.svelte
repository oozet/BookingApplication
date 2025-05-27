<script lang="ts">
	// We'll fetch this data in th slug page server and then send it
	// as a prop to this component to make the component be more of a component.
	let { booking = {}, user = {}, room = {}, activity = {} } = $props();
</script>

<div class="booking-card">
	<h2>Booking</h2>
	<p><strong>Room#:</strong> {room.Number}</p>
	<p><strong>Activity:</strong> {activity.Name}</p>
	<p><strong>Booker:</strong> {user.Name}</p>
</div>

<style>
	.booking-card {
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}
</style>
