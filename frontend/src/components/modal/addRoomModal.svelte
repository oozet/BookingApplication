<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import { RoomApi } from '../../api/room';
	import { isModalVisible } from '$lib/shared.svelte';

	let message = $state('');

	let name: string = $state('');
	let roomnumber: number = $state(0);
	let limit: number = $state(0);
	let area: number = $state(0);
	let price: number = $state(0);

	async function addRoom(event: SubmitEvent) {
		event.preventDefault();
		message = await RoomApi.Create(name, roomnumber, limit, area, price);

		invalidateAll();
	}
</script>

<div class="add-room-modal">
	<h3>Add Room</h3>
	<p>{message}</p>
	<form onsubmit={addRoom}>
		<label for="">
			Name: <input type="text" bind:value={name} />
		</label>
		<label for="">
			RoomNumber: <input type="number" bind:value={roomnumber} />
		</label>
		<label for="">
			Limit: <input type="number" bind:value={limit} />
		</label>
		<label for="">
			Area: <input type="number" bind:value={area} />
		</label>
		<label for="">
			Price: <input type="number" bind:value={price} />
		</label>
		<button type="submit">Create Room</button>
	</form>
	<button class="close" onclick={() => (isModalVisible.addRoomModal = !isModalVisible.addRoomModal)}
		>X</button
	>
</div>

<style>
	.add-room-modal {
		z-index: 100;
		position: fixed;
		top: 15%;
		left: 15%;
		width: 70%;
		height: 70%;
		background-color: #bcc4dbff;
		border: 2px solid rgb(178, 186, 207);
		border-radius: 10px;

		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}

	p {
		text-align: center;
	}

	.add-room-modal form {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}

	.close {
		background-color: #ee6c4dff;
		color: white;
		border: none;
		height: 2.6rem;
		line-height: 2.6rem;
		width: 2.6rem;
		margin-top: auto;
		margin-left: auto;
	}
</style>
