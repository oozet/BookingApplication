<script lang="ts">
    import { onMount } from 'svelte';
    import { userStore, userBookingsStore, fetchUserBookings, type Booking } from '../stores/userStore';
    
    let bookings: Booking[] = [];
    let loading = true;
    let error = '';

    // Subscribe to the bookings store
    $: bookings = $userBookingsStore;

    onMount(async () => {
        if ($userStore) {
            try {
                await fetchUserBookings();
            } catch (err) {
                error = err instanceof Error ? err.message : 'Failed to load bookings';
            } finally {
                loading = false;
            }
        } else {
            loading = false;
            error = 'Please log in to view your bookings';
        }
    });

    function formatDate(dateString: string): string {
        return new Date(dateString).toLocaleString();
    }

    function getStatusColor(status: string): string {
        switch (status.toLowerCase()) {
            case 'confirmed': return 'text-green-600';
            case 'pending': return 'text-yellow-600';
            case 'cancelled': return 'text-red-600';
            default: return 'text-gray-600';
        }
    }
</script>

<div class="container mx-auto px-4 py-8">
    <h1 class="text-3xl font-bold mb-8">My Bookings</h1>

    {#if loading}
        <div class="flex justify-center items-center py-8">
            <div class="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600"></div>
        </div>
    {:else if error}
        <div class="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded mb-4">
            {error}
        </div>
    {:else if bookings.length === 0}
        <div class="text-center py-8">
            <p class="text-gray-600 text-lg">You don't have any bookings yet.</p>
            <a href="/book" class="inline-block mt-4 bg-blue-600 text-white px-6 py-2 rounded hover:bg-blue-700 transition-colors">
                Make a Booking
            </a>
        </div>
    {:else}
        <div class="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
            {#each bookings as booking}
                <div class="bg-white rounded-lg shadow-md border border-gray-200 p-6">
                    <div class="flex justify-between items-start mb-4">
                        <h3 class="text-lg font-semibold text-gray-800">
                            {booking.room?.name || booking.activity?.name || 'Booking'}
                        </h3>
                        <span class="px-2 py-1 text-sm rounded-full {getStatusColor(booking.status)} bg-gray-100">
                            {booking.status}
                        </span>
                    </div>

                    {#if booking.room}
                        <div class="mb-3">
                            <p class="text-sm text-gray-600">Room</p>
                            <p class="font-medium">{booking.room.name}</p>
                            <p class="text-sm text-gray-500">Capacity: {booking.room.capacity}</p>
                        </div>
                    {/if}

                    {#if booking.activity}
                        <div class="mb-3">
                            <p class="text-sm text-gray-600">Activity</p>
                            <p class="font-medium">{booking.activity.name}</p>
                            {#if booking.activity.description}
                                <p class="text-sm text-gray-500">{booking.activity.description}</p>
                            {/if}
                        </div>
                    {/if}

                    <div class="space-y-2">
                        <div>
                            <p class="text-sm text-gray-600">Start Time</p>
                            <p class="font-medium">{formatDate(booking.startTime)}</p>
                        </div>
                        <div>
                            <p class="text-sm text-gray-600">End Time</p>
                            <p class="font-medium">{formatDate(booking.endTime)}</p>
                        </div>
                    </div>

                    <div class="mt-4 pt-4 border-t border-gray-100">
                        <div class="flex space-x-2">
                            <button class="flex-1 bg-blue-600 text-white px-4 py-2 rounded text-sm hover:bg-blue-700 transition-colors">
                                View Details
                            </button>
                            {#if booking.status.toLowerCase() !== 'cancelled'}
                                <button class="flex-1 bg-red-600 text-white px-4 py-2 rounded text-sm hover:bg-red-700 transition-colors">
                                    Cancel
                                </button>
                            {/if}
                        </div>
                    </div>
                </div>
            {/each}
        </div>
    {/if}
</div>

<style>
    .container {
        max-width: 1200px;
    }
</style>