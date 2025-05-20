<script lang="ts">
	import { Hamburger } from 'svelte-hamburgers';
	import { slide } from 'svelte/transition';

	let open = $state(false);
</script>

<nav>
	<div class="left-nav"></div>
	<div class="middle-nav"><h1>Booking Application</h1></div>
	<div class="right-nav">
		<Hamburger bind:open title="Toogle a menu with navigation" --color="white" type="minus" />
	</div>
</nav>
{#if open}
	<div class="hamburger-dropdown" transition:slide>
		<h3><a href="/">Home</a></h3>
		<h3><a href="/about">About</a></h3>
		<h3><a href="/booking">Booking</a></h3>
	</div>
{/if}

<style>
	nav {
		display: grid;
		grid-template-columns: 2fr 8fr 2fr;
		background-color: skyblue;
		width: 100vw;
		height: 4rem;
		gap: 0.5rem;
		flex-shrink: 0;
	}

	.middle-nav {
		display: flex;
		align-items: center;
		justify-content: center;
	}
	.middle-nav > h1 {
		color: white;
	}
	.right-nav {
		display: flex;
		justify-content: end;
		align-items: center;
	}

	.hamburger-dropdown {
		height: 40vh;
		background-color: skyblue;
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}

	.hamburger-dropdown h3 {
		margin: 0.5rem;
	}

	.hamburger-dropdown a {
		text-decoration: none;
		color: white;
	}
</style>
