window.onload = function () {
	var canvas = document.getElementById('canvas');
	var ctx = canvas.getContext('2d');

	ctx.fillStyle = 'rgba(95, 149, 211, 1)';
	ctx.fillRect(0, 0, 256, 256);

	ctx.fillStyle = 'rgba(249, 255, 70, 1)';
	ctx.fillRect(64, 64, 128, 128);
};