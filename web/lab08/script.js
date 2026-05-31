const slides = [
	{
		src: "assets/images/gallery-07.jpg",
		href: "assets/images/gallery-07.jpg",
		alt: "Горный пейзаж",
	},
	{
		src: "assets/images/gallery-05.jpg",
		href: "assets/images/gallery-05.jpg",
		alt: "Городской пейзаж",
	},
	{
		src: "assets/images/gallery-04.jpg",
		href: "assets/images/gallery-04.jpg",
		alt: "Лесной пейзаж",
	},
];

let currentSlide = 0;
const slideImage = document.querySelector("#slideImage");
const slideLink = document.querySelector("#slideLink");
const slideDots = document.querySelectorAll(".slide-dot");

function showSlide(index) {
	const slide = slides[index];
	slideImage.src = slide.src;
	slideImage.alt = slide.alt;
	slideLink.href = slide.href;

	slideDots.forEach((dot, dotIndex) => {
		dot.classList.toggle("slide-dot--active", dotIndex === index);
	});
}

setInterval(() => {
	currentSlide = (currentSlide + 1) % slides.length;
	showSlide(currentSlide);
}, 1000);

const galleryTrack = document.querySelector("#galleryTrack");
const galleryPrev = document.querySelector("#galleryPrev");
const galleryNext = document.querySelector("#galleryNext");
const galleryItems = document.querySelectorAll(".gallery__item");
let galleryPosition = 0;
const visibleItems = 3;
const maxPosition = galleryItems.length - visibleItems;

function updateGallery() {
	const viewport = document.querySelector(".gallery__viewport");
	const gap = parseFloat(getComputedStyle(galleryTrack).gap);
	const itemWidth = galleryItems[0].getBoundingClientRect().width;
	const offset = galleryPosition * (itemWidth + gap);

	galleryTrack.style.transform = `translateX(-${offset}px)`;
	galleryPrev.disabled = galleryPosition === 0;
	galleryNext.disabled = galleryPosition === maxPosition;
	viewport.setAttribute("aria-live", "polite");
}

galleryPrev.addEventListener("click", () => {
	if (galleryPosition > 0) {
		galleryPosition -= 1;
		updateGallery();
	}
});

galleryNext.addEventListener("click", () => {
	if (galleryPosition < maxPosition) {
		galleryPosition += 1;
		updateGallery();
	}
});

window.addEventListener("resize", updateGallery);
updateGallery();
