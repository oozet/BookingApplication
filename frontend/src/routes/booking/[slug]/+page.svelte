<script lang="ts">
	import BookingCard from '../../../components/bookingCard.svelte';

	let { data } = $props();

	// some mock data to send as a prop, for testing.
	// let booking = {
	// 	Id: 'mock Id for booking',
	// 	StartDate: 'Add a date here',
	// 	EndDate: 'Add a date here as well'
	// };

	let booking = data.booking;

	let user = {
		Id: 'mock id for the user',
		Name: 'Mock Mockson'
	};

	// let room = {
	// 	Id: 'mock id for the room',
	// 	Number: 404,
	// 	Name: 'Made up'
	// };

	let room = data.room;

	let activity = {
		Id: 'Mock id for the activity',
		Name: 'Mock Activity Name',
		Description: 'Activity description'
	};
</script>

Hello from booking/{data.slug}

<BookingCard {booking} {user} {room} {activity} />
