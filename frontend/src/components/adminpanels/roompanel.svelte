<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import { API_BASE_URL } from '$lib/constants';
	import { RoomApi } from '../../api/room';
	import AddRoomModal from '../modal/addRoomModal.svelte';
	import { isModalVisible } from '$lib/shared.svelte';

	let { rooms } = $props();

	let message: string = $state('');

	async function deleteRoom(id: string) {
		message = (await RoomApi.Delete(id)).toString();

		invalidateAll();
	}
</script>

<p>{message}</p>

<div class="roompanel">
	<button
		class="add"
		onclick={() => {
			isModalVisible.addRoomModal = !isModalVisible.addRoomModal;
		}}
	>
		Add New Room</button
	>

	{#each rooms as room}
		<div class="room" style="margin-bottom: 0.5rem;">
			<p style="margin: 0;">
				Room#: {room.roomNumber}, Name: {room.name}, Limit: {room.limit}, Area: {room.area}, Price: {room.price}
			</p>
			<button class="edit">Edit</button>
			<button
				class="delete"
				onclick={() => {
					deleteRoom(room.id);
				}}>Delete</button
			>
		</div>
	{/each}
</div>

{#if isModalVisible.addRoomModal}
	<AddRoomModal />
{/if}

<style>
	.roompanel {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}

	.room {
		display: flex;
		gap: 0.2rem;
	}

	.add {
		margin-bottom: 2rem;
	}
</style>
