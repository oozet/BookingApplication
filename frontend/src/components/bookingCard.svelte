<script lang="ts">
	// We'll fetch the booking here
	// but for dev purposes I'm just mocking a booking so I can easily see how things
	// would look.
	let booking = {
		Id: 'mock Id for booking',
		RoomId: 'mock id for the room',
		UserId: 'mock id for the user',
		ActivityId: 'Mock id for the activity',
		StartDate: 'Add a date here',
		EndDate: 'Add a date here as well'
	};

	// afterwards, we'd fetch the room and the user, so we can render the
	// username and the room number/room name. But still know which Id
	// they are connect to incase the user wants to press them and get sent to
	// the appropiate page.
</script>

<div class="booking-card">
	<h1></h1>
</div>

<style>
</style>
