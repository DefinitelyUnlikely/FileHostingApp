<script lang="ts">
	import { isLoggedIn, Logout } from '../stores/auth';
</script>

<footer>
	<h3>
		By <a href="https://github.com/DefinitelyUnlikely">DefinitelyUnlikely @ GitHub</a>
	</h3>
	{#if isLoggedIn}
		<button class="logout" onclick={Logout}>Logout</button>
	{/if}
</footer>

<style>
	footer {
		background-color: var(--color);
		width: 100vw;
		height: 4rem;
		flex-shrink: 0;
		display: flex;
		justify-content: center;
		align-items: center;
	}

	footer a {
		text-decoration: none;
		color: rgb(255, 255, 255);
	}

	.logout {
		justify-self: end;
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
