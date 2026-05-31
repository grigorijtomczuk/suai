function getSumDeclaration() {
	return 15 + 27;
}

const getSumExpression = function () {
	return 15 + 27;
};

const getSumArrow = () => 15 + 27;

function showFunctionResult(methodName, result) {
	const resultElement = document.getElementById("functionResult");

	if (resultElement) {
		resultElement.textContent = `${methodName}: 15 + 27 = ${result}`;
	}
}

function addTodoItem(text, position) {
	const todoList = document.getElementById("todoList");

	if (!todoList) {
		return;
	}

	const item = document.createElement("li");
	item.textContent = text;

	if (position === "start") {
		todoList.prepend(item);
		return;
	}

	if (position === "middle") {
		const middleIndex = Math.floor(todoList.children.length / 2);
		todoList.insertBefore(item, todoList.children[middleIndex]);
		return;
	}

	todoList.append(item);
}

function showFriends() {
	const friends = ["Алексей", "Мария", "Иван", "Екатерина"];

	friends.forEach((friend) => {
		alert(friend);
	});
}

document.addEventListener("DOMContentLoaded", () => {
	document.getElementById("declarationBtn")?.addEventListener("click", () => {
		showFunctionResult("Function Declaration", getSumDeclaration());
	});

	document.getElementById("expressionBtn")?.addEventListener("click", () => {
		showFunctionResult("Function Expression", getSumExpression());
	});

	document.getElementById("arrowBtn")?.addEventListener("click", () => {
		showFunctionResult("Arrow Function", getSumArrow());
	});

	document.getElementById("addMorningBtn")?.addEventListener("click", () => {
		addTodoItem("Утренняя пробежка", "start");
	});

	document.getElementById("addExhibitionBtn")?.addEventListener("click", () => {
		addTodoItem("Выставка", "middle");
	});

	document.getElementById("addTheatreBtn")?.addEventListener("click", () => {
		addTodoItem("Театр", "end");
	});

	document.getElementById("friendsBtn")?.addEventListener("click", showFriends);
});
