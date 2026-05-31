const operators = [
	{ name: "МТС", subscribers: 81.8 },
	{ name: "МегаФон", subscribers: 67.7 },
	{ name: "Ростелеком / T2", subscribers: 48.1 },
	{ name: "Билайн", subscribers: 44.1 },
	{ name: "Yota", subscribers: 9.5 },
];

function runIntroAnimation() {
	anime({
		targets: ".intro__content > *",
		translateY: [28, 0],
		opacity: [0, 1],
		delay: anime.stagger(130),
		duration: 900,
		easing: "easeOutCubic",
	});

	anime({
		targets: ".stat-card",
		translateY: [34, 0],
		scale: [0.94, 1],
		opacity: [0, 1],
		delay: anime.stagger(140, { start: 350 }),
		duration: 900,
		easing: "easeOutElastic(1, .72)",
	});

	anime({
		targets: "#simCard",
		translateY: [-10, 10],
		rotate: [-2, 2],
		duration: 2400,
		direction: "alternate",
		loop: true,
		easing: "easeInOutSine",
	});

	anime({
		targets: ".signal",
		scale: [0.75, 1.1],
		opacity: [0.75, 0.12],
		delay: anime.stagger(420),
		duration: 1800,
		direction: "alternate",
		loop: true,
		easing: "easeInOutQuad",
	});
}

function createOperatorsChart() {
	const canvas = document.getElementById("operatorsChart");

	return new Chart(canvas, {
		type: "bar",
		data: {
			labels: operators.map((operator) => operator.name),
			datasets: [
				{
					label: "Количество абонентов, млн",
					data: operators.map((operator) => operator.subscribers),
					backgroundColor: ["#0a8f7a", "#2f6fed", "#e84a5f", "#f2a516", "#6a5acd"],
					borderRadius: 6,
					borderSkipped: false,
				},
			],
		},
		options: {
			indexAxis: "y",
			responsive: true,
			maintainAspectRatio: false,
			animation: {
				duration: 1200,
				easing: "easeOutQuart",
			},
			plugins: {
				legend: {
					display: false,
				},
				tooltip: {
					callbacks: {
						label(context) {
							return `${context.parsed.x} млн абонентов`;
						},
					},
				},
				title: {
					display: true,
					text: "Крупнейшие операторы по количеству абонентов",
					color: "#172033",
					font: {
						size: 18,
						weight: "bold",
					},
					padding: {
						bottom: 18,
					},
				},
			},
			scales: {
				x: {
					beginAtZero: true,
					title: {
						display: true,
						text: "Абоненты, млн",
					},
					grid: {
						color: "#e7ebf3",
					},
				},
				y: {
					grid: {
						display: false,
					},
					ticks: {
						color: "#172033",
						font: {
							size: 14,
							weight: "bold",
						},
					},
				},
			},
		},
	});
}

window.addEventListener("DOMContentLoaded", () => {
	runIntroAnimation();
	createOperatorsChart();

	document.getElementById("replayAnimation").addEventListener("click", () => {
		anime.remove(".intro__content > *, .stat-card");
		runIntroAnimation();
	});
});
