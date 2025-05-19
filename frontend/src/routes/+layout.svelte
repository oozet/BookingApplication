<script lang="ts">
	import Navbar from '../components/navbar.svelte';

	let { children } = $props();
</script>

<Navbar />

{@render children()}
