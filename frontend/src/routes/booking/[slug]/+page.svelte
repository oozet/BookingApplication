<script lang="ts">
	import type { PageData } from './$types';
	import BookingCard from '../../../components/bookingCard.svelte';

	let { data }: { data: PageData } = $props();

	let booking = data.booking;
	let user = data.user;
	let room = data.room;
	let activity = data.activity;
</script>

<BookingCard {booking} {user} {room} {activity} />
