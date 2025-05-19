<script lang="ts">
	import '../../static/global.css';
	import Navbar from '../components/navbar.svelte';

	let { children } = $props();
</script>

<Navbar />

{@render children()}
