<script>
	import Register from '../components/register.svelte';
	import Create from '../components/create.svelte';
	import Upload from '../components/upload.svelte';
</script>

<h1>Testing the file database</h1>

<Register />
<Create />
<Upload />

<style>
	:global(body) {
		background-color: rgb(41, 41, 41);
		margin: 0;
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}

	:global(h1) {
		color: white;
	}

	:global(h2) {
		color: white;
	}

	:global(p) {
		color: white;
	}

	:global(label) {
		color: white;
	}
</style>
