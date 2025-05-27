<script lang="ts">
	import BookingCard from '../../../components/bookingCard.svelte';

	let { data } = $props();

	// some mock data to send as a prop, for testing.
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

Hello from booking/{data.slug}

<BookingCard {booking} {user} {room} {activity} />
