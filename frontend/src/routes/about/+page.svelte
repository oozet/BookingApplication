<script lang="ts">
	let creators: string[] = $state(['Anthon', 'Cedric', 'Martin', 'Olof']);

	let visible: boolean = $state(false);

	function changeVisibility() {
		visible = !visible;
	}
</script>

<p>
	Detta är just nu en route jag använder för att visa hur 1. Routing funkar i svelte. 2. Vissa
	forloop och if satser.
</p>

<p>
	Routing funkar alltså så enkelt att vi skapar en mapp under routes mappen, där namnet är routen vi
	vill använda. T.ex. att jag nu gjort en /about route genom att skapa en mapp med namnet about. I
	den lägger man en fil vid namn +page.svelte. Den är det som renderas när man är på den routen.
</p>

<button onclick={changeVisibility}>Vilka är med i gruppen?</button>

{#if visible}
	<ul>
		{#each creators as creator}
			<li>{creator}</li>
		{/each}
	</ul>
{/if}

<style>
</style>
