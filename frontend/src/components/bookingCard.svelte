<script lang="ts">
	// We'll fetch this data in th slug page server and then send it
	// as a prop to this component to make the component be more of a component.
	let booking = {
		Id: 'mock Id for booking',
		RoomId: 'mock id for the room',
		UserId: 'mock id for the user',
		ActivityId: 'Mock id for the activity',
		StartDate: 'Add a date here',
		EndDate: 'Add a date here as well'
	};

	let user = {
		Id: 'mock id for the user',
		Name: 'Mock Mockson'
	};

	let room = {
		Id: 'mock id for the room',
		Number: 404,
		Name: 'Made up'
	};

	let activity = {
		Id: 'Mock id for the activity',
		Name: 'Activity Name',
		Description: 'Activity description'
	};
</script>

<div class="booking-card">
	<h2>Booking</h2>
	<p><strong>Room#: </strong>{room.Number}</p>
	<p><strong>Activity: </strong>{activity.Name}</p>
	<p><strong>Booker: </strong>{user.Name}</p>
</div>

<style>
	.booking-card {
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}
</style>
