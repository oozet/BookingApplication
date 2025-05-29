<script lang="ts">
  import { onMount } from 'svelte';
  import { ActivityApi, type Activity } from '../api/activity';

  let activities: Activity[] = [];
  let loading = true;
  let error: string | null = null;

  async function loadActivities() {
    try {
      loading = true;
      error = null;
      activities = await ActivityApi.getAll();
    } catch (err) {
      error = err instanceof Error ? err.message : 'An unknown error occurred';
    } finally {
      loading = false;
    }
  }

  onMount(() => {
    loadActivities();
  });

  function retry() {
    loadActivities();
  }
</script>

<div class="activityList">
  <h2>Activities</h2>

  {#if loading}
    <p>Loading activities...</p>
  {:else if error}
    <p>Error: {error} <button on:click={retry}>Retry</button></p>
  {:else}
    <ul>
      {#each activities as activity}
        <li>
          <strong>{activity.name}</strong>
          {#if activity.description}
            <p>{activity.description}</p>
          {/if}
        </li>
      {/each}
    </ul>
  {/if}
</div>

<style>
  .activityList {
    padding: 1rem;
  }
  ul {
    list-style: none;
    padding: 0;
  }
  li {
    margin-bottom: 1rem;
    padding: 1rem;
    background: white;
    border-radius: 4px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  }
</style>