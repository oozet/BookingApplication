<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import { ActivityApi } from '../../api/activity';
	import { isModalVisible } from '$lib/shared.svelte';

	let message = $state('');

	let name: string = $state('');
	let desc: string = $state('');

	async function addActivity(event: SubmitEvent) {
		event.preventDefault();
		message = await ActivityApi.Create(name, desc);

		invalidateAll();
	}
</script>

<p>{message}</p>
<div class="add-act-modal">
	<form onsubmit={addActivity}>
		<label for="">
			Name: <input type="text" bind:value={name} />
		</label>
		<label for="">
			Description: <input type="text" bind:value={desc} />
		</label>
		<button type="submit">Create Room</button>
	</form>
	<button
		class="close"
		onclick={() => (isModalVisible.addActivityModal = !isModalVisible.addActivityModal)}>X</button
	>
</div>

<style>
	.add-act-modal {
		z-index: 100;
		position: fixed;
		width: 90%;
		height: 70%;
		background-color: #ebebebff;
		border: 2px solid #d6d6d6ff;
		border-radius: 10px;

		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}

	p {
		text-align: center;
	}

	.add-act-modal form {
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
