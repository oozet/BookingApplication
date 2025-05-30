<script lang="ts">
	let { activities } = $props();
</script>

<div class="activitypanel">
	<button class="add"> Add New Activity</button>

	{#each activities as activity}
		<div class="activity">
			<p>Name: {activity.name}, Description: {activity.description}</p>
			<button class="edit">Edit</button>
			<button class="delete">Delete</button>
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
