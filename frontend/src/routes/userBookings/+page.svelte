<script lang="ts">
    import { onMount } from 'svelte';
    import { goto } from '$app/navigation';
    import { userStore } from '../../stores/userStore';
    import UserBookings from '../../components/userBookings.svelte';

    onMount(() => {
        // Check if user is logged in, redirect to login if not
        if (!$userStore) {
            goto('/login');
        }
    });
</script>

<svelte:head>
    <title>My Bookings</title>
</svelte:head>

{#if $userStore}
    <UserBookings />
{:else}
    <div class="flex justify-center items-center min-h-screen">
        <div class="text-center">
            <h2 class="text-2xl font-bold mb-4">Please Log In</h2>
            <p class="text-gray-600 mb-4">You need to be logged in to view your bookings.</p>
            <a href="/login" class="bg-blue-600 text-white px-6 py-2 rounded hover:bg-blue-700 transition-colors">
                Go to Login
            </a>
        </div>
    </div>
{/if}