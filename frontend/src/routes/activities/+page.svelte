<script lang="ts">
import ActivityList from '../../components/activityList.svelte';
</script>

<svelte:head>
  <title>Activities</title>
  <meta name="description" content="View all activities" />
</svelte:head>

<main>
  <ActivityList />
</main>

<style>
  main {
    min-height: 100vh;
    background-color: #f8f9fa;
  }
</style>
