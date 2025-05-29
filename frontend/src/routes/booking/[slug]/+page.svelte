<script lang="ts">
	import BookingCard from '../../../components/bookingCard.svelte';

	let { data } = $props();

	let booking = data.booking;
	let user = data.user;
	let room = data.room;
	let activity = data.activity;
</script>

<BookingCard {booking} {user} {room} {activity} />
