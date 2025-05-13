<script lang="ts">
	import Hamburger from './hamburger.svelte';
</script>

<nav>
	<div class="left-nav"></div>
	<div class="middle-nav">File app</div>
	<div class="right-nav">
		<Hamburger />
		<!-- <a href="/">Home</a>
		<a href="/register">Register</a>
		<a href="/login">Login</a> -->
	</div>
</nav>

<style>
	nav {
		display: grid;
		grid-template-columns: 2fr 8fr 2fr;
		background-color: rgb(40, 109, 238);
		width: 100vw;
		height: 4rem;
		gap: 0.5rem;
	}

	.middle-nav {
		display: flex;
		align-items: center;
		justify-content: center;
	}
	.right-nav {
		display: flex;
		justify-content: end;
		align-items: center;
	}
	a {
		text-decoration: none;
		color: white;
	}
</style>
