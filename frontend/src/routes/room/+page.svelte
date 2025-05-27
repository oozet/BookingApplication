<script lang="ts">
	import { onMount } from 'svelte';

	let data: any = null;
	let loading = true;
	let error: string | null = null;
	let rooms: Array<any> = [];

	async function fetchRooms() {
		try {
			const response = await fetch('http://localhost:5133/room/', {
				method: 'GET',
				credentials: 'include'
			});
			if (!response.ok) throw new Error('Failed to fetch');
			rooms = await response.json();
		} catch (err: any) {
			error = err.message;
		} finally {
			loading = false;
		}
	}

	onMount(fetchRooms);
</script>

{#if loading}
	<p>Loading...</p>
{:else if error}
	<p class="error">{error}</p>
{:else}
	<div class="room-list">
		{#each rooms as room (room.id)}
            <div>
                <h2>{room.name}</h2>
                <p>Number: {room.RoomNumber}</p>
                <p>Area: {room.Area}</p>
                <p>Limit: {room.Limit}</p>
                <p>Price: {room.Price}</p>
                <button>Book room</button>
            </div>
		{/each}
	</div>
{/if}

<style>
	.error {
		color: red;
	}
</style>
