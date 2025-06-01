<script lang="ts">
	import { onMount } from 'svelte';
	import { userStore } from '../../api/user';
	import { goto } from '$app/navigation';

	let data: any = null;
	let loading = true;
	let error: string | null = null;
	let rooms: Array<any> = [];

	let user: any;
	$: userStore.subscribe((value) => (user = value));

	async function fetchRooms() {
		try {
			const response = await fetch('http://localhost:5133/room/', {
				method: 'GET',
				credentials: 'include'
			});
			if (!response.ok) throw new Error('Failed to fetch');
			rooms = await response.json();
			console.log(rooms);
		} catch (err: any) {
			error = err.message;
		} finally {
			loading = false;
		}
	}

	function bookRoom(roomId: string) {
		goto(`/createBooking/${roomId}`);
	}

	onMount(fetchRooms);
</script>

{#if loading}
	<p>Loading...</p>
{:else if error}
	<p class="error">{error}</p>
{:else}
	<div>{user.username},{user.id}</div>
	<div class="room-list">
		{#each rooms as room (room.id)}
			<div>
				<h2>{room.name}</h2>
				<p>Id: {room.id}</p>
				<p>Number: {room.roomNumber}</p>
				<p>Area: {room.area}</p>
				<p>Limit: {room.limit}</p>
				<p>Price: {room.price}</p>
				<button onclick={() => bookRoom(room.id)}>Book room</button>
			</div>
		{/each}
	</div>
{/if}

<style>
	.error {
		color: red;
	}
</style>
