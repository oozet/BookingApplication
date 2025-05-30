<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import { ActivityApi } from '../../api/activity';

	let { activities } = $props();

	let message: string = $state('');

	async function deleteActivity(id: string) {
		message = (await ActivityApi.Delete(id)).toString();

		invalidateAll();
	}
</script>

<div class="activitypanel">
	<button class="add"> Add New Activity</button>

	{#each activities as activity}
		<div class="activity">
			<p>Name: {activity.name}, Description: {activity.description}</p>
			<button class="edit">Edit</button>
			<button
				class="delete"
				onclick={() => {
					deleteActivity(activity.id);
				}}>Delete</button
			>
		</div>
	{/each}
</div>

<style>
	.activitypanel {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}

	.activity {
		display: flex;
		gap: 0.2rem;
	}

	.add {
		margin-bottom: 2rem;
	}
</style>
