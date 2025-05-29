<script lang="ts">
	function NewFolder() {}
</script>

<div class="folder-modal">
	<h3>Create Folder</h3>
	<p>The folder will be created in the current directory</p>
	<form onsubmit={NewFolder}>
		<label for="folder-name">Folder name</label>
		<input name="folder-name" type="text" />
		<button type="submit">Create</button>
	</form>
	<button class="close" style="background-color:#ee6c4dff">Close</button>
</div>

<style>
	.folder-modal {
		z-index: 100;
		position: fixed;
		width: 90%;
		height: 70%;
		background-color: #ebebebff;
		border: 2px solid #d6d6d6ff;
		border-radius: 10px;

		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}

	.folder-modal form {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}

	button {
		--color: #0e79b2ff;
		font-family: inherit;
		width: 6em;
		height: 2.6em;
		line-height: 2.5em;
		overflow: hidden;
		cursor: pointer;
		margin: 20px;
		font-size: 17px;
		z-index: 1;
		color: var(--color);
		border: 2px solid var(--color);
		border-radius: 6px;
		position: relative;
	}

	button::before {
		position: absolute;
		content: '';
		background: var(--color);
		width: 150px;
		height: 200px;
		z-index: -1;
		border-radius: 50%;
	}

	button:hover {
		color: white;
	}

	button:before {
		top: 100%;
		left: 100%;
		transition: 0.3s all;
	}

	button:hover::before {
		top: -30px;
		left: -30px;
	}
</style>
