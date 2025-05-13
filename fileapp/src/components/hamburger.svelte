<script lang="ts">
	function activeHam() {}
</script>

<div class="ham-menu">
	<span id="top-span"></span>
	<span id="middle-span"></span>
	<span id="bottom-span"></span>
</div>

<style>
	.ham-menu {
		height: 50px;
		width: 40px;
		margin-left: auto;
		position: relative;
		margin: 0.25rem;
		z-index: 1000;
	}

	.ham-menu:hover {
		cursor: pointer;
	}

	.ham-menu span {
		height: 5px;
		width: 100%;
		background-color: #faebd7;
		border-radius: 25px;
		position: absolute;
		left: 50%;
		top: 50%;
		transform: translate(-50%, -50%);
		transition: 0.3s ease;
	}

	.ham-menu span:nth-child(1) {
		top: 25%;
	}

	.ham-menu span:nth-child(3) {
		top: 75%;
	}

	.ham-menu.active {
		position: relative;
		z-index: 1001;
	}

	.ham-menu.active span {
		background-color: #faebd7;
	}

	.ham-menu.active span:nth-child(1) {
		top: 50%;
		transform: translate(-50%, -50%) rotate(45deg);
	}

	.ham-menu.active span:nth-child(2) {
		opacity: 0;
	}

	.ham-menu.active span:nth-child(3) {
		top: 50%;
		transform: translate(-50%, -50%) rotate(-45deg);
	}
</style>
