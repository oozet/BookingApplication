<script lang="ts">
</script>

<nav class="nav-bar">
	<div class="topnav">
		<h1 class="title">Booking Application</h1>
	</div>
	<div class="bottomnav">
		<div class="bottom-left">
			<a href="/">Home</a><a href="/about">About</a><a href="/booking">Booking</a>
		</div>
		<div class="bottom-middle"></div>
		<div class="bottom-right"></div>
	</div>
</nav>

<style>
	.nav-bar {
		background-color: gray;
		width: 100%;
		margin: 0;
	}

	.nav-bar {
		color: white;
	}

	.topnav {
		display: flex;
		justify-content: center;
		align-items: center;
		flex-direction: column;
		height: 4rem;
		margin-top: 0.5rem;
	}

	.title {
		color: white;
	}

	nav a,
	nav a:visited {
		color: white;
		text-decoration: none;
	}

	nav a:hover {
		color: orange;
	}

	.bottomnav {
		display: none;
	}

	.bottomnav {
		display: grid;
		grid-template-columns: 2fr 8fr 2fr;
		height: 2rem;
	}

	.bottom-left {
		display: flex;
		gap: 1rem;
		justify-content: flex-start;
		align-items: center;
		margin-left: 1rem;
	}

	.bottom-middle {
		display: flex;
		justify-content: center;
		align-items: center;
	}

	.bottom-right {
		display: flex;
		justify-content: flex-end;
		align-items: center;
		margin-right: 1rem;
	}
</style>
