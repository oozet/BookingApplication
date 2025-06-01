<!-- <script lang="ts">
    import { onMount } from 'svelte';

    let data: any = null;
    let loading = true;
    let error: string | null = null;

    let startDate = "";
    let endDate = "";
    let roomId = "";
    let userId = "";
    let activityId = "";
    let booking = {startDate : "", endDate : "", roomId : "", userId : "", activityId: ""};

    async function fetchBooking() {
        try {
            const response = await fetch('http://localhost:5133/booking/', {
                method: 'POST',
                credentials: 'include',
                body: JSON.stringify(booking)
            });
            if (!response.ok) throw new Error('Failed to fetch');
            data = await response.json();
        } catch (err: any) {
            error = err.message;
        } finally {
            loading = false;
        }
    }

    onMount(fetchBooking);

</script>

{#if loading}
    <p>Loading...</p>
{:else if error}
    <p class="error">{error}</p>
{:else}
    <p>Data: {JSON.stringify(data)}</p>
{/if}

<style>
    .error { color: red; }
</style> -->
