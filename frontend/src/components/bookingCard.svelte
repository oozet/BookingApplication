<script lang="ts">
	// We'll fetch the booking here
	// but for dev purposes I'm just mocking a booking so I can easily see how things
	// would look. 
    // NOTE: This will be done in our +page.server.svelte file for the slug route.
	let booking = {
		Id: 'mock Id for booking',
		RoomId: 'mock id for the room',
		UserId: 'mock id for the user',
		ActivityId: 'Mock id for the activity',
		StartDate: 'Add a date here',
		EndDate: 'Add a date here as well'
	};

	// afterwards, we'd fetch the room and the user and activity, so we can render the
	// username and the room number/room name. But still know which Id
	// they are connect to incase the user wants to press them and get sent to
	// the appropiate page.

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
        Name: "Activity Name",
        Description: "Activity description"
    }
</script>

<div class="booking-card">
	<h2>Booking</h2>
	<p><strong>Room#: </strong>{room.Number}</p>
    <p><strong>Activity: </strong>{activity.Name}</p>
    <p><strong>Booker: </strong>{user.Name}</p>
    <p><strong></strong>{}</p>
    <p><strong></strong>{}</p>
</div>

<style>
	.booking-card {
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}
</style>
