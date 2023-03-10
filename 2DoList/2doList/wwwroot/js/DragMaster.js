var dragMaster = (function () {

	var dragObject
	var mouseDownAt

	var currentDropTarget


	function mouseDown(e) {
		e = fixEvent(e)
		if (e.which != 1) return

		mouseDownAt = { x: e.pageX, y: e.pageY, element: this }

		addDocumentEventHandlers()

		return false
	}


	function mouseMove(e) {
		e = fixEvent(e)

		// (1)
		if (mouseDownAt) {
			if (Math.abs(mouseDownAt.x - e.pageX) < 5 && Math.abs(mouseDownAt.y - e.pageY) < 5) {
				return false
			}
			// Начать перенос
			var elem = mouseDownAt.element
			// текущий объект для переноса
			dragObject = elem.dragObject

			// запомнить, с каких относительных координат начался перенос
			var mouseOffset = getMouseOffset(elem, mouseDownAt.x, mouseDownAt.y)
			mouseDownAt = null // запомненное значение больше не нужно, сдвиг уже вычислен

			dragObject.onDragStart(mouseOffset) // начали

		}

		// (2)
		dragObject.onDragMove(e.pageX, e.pageY)

		// (3)
		var newTarget = getCurrentTarget(e)

		// (4)
		if (currentDropTarget != newTarget) {
			if (currentDropTarget) {
				currentDropTarget.onLeave()
			}
			if (newTarget) {
				newTarget.onEnter()
			}
			currentDropTarget = newTarget

		}

		// (5)
		return false
	}


	function mouseUp() {
		if (!dragObject) { // (1)
			mouseDownAt = null
		} else {
			// (2)
			currentDropTarget.accept(dragObject)
			dragObject.onDragSuccess(currentDropTarget)
			

			dragObject = null
		}

		// (3)
		removeDocumentEventHandlers()
	}


	function getMouseOffset(target, x, y) {
		var docPos = getOffset(target)
		return { x: x - docPos.left, y: y - docPos.top }
	}


	function getCurrentTarget(e) {
		// спрятать объект, получить элемент под ним - и тут же показать опять

		if (navigator.userAgent.match('MSIE') || navigator.userAgent.match('Gecko')) {
			var x = e.clientX, y = e.clientY
		} else {
			var x = e.pageX, y = e.pageY
		}
		// чтобы не было заметно мигание - максимально снизим время от hide до show
		dragObject.hide()
		var elem = document.elementFromPoint(x, y)
		dragObject.show()

		// найти самую вложенную dropTarget
		while (elem) {
			// которая может принять dragObject 
			if (elem.dropTarget && elem.dropTarget.canAccept(dragObject)) {
				return elem.dropTarget
			}
			elem = elem.parentNode
		}

		// dropTarget не нашли
		return null
	}


	function addDocumentEventHandlers() {
		document.onmousemove = mouseMove
		document.onmouseup = mouseUp
		document.ondragstart = document.body.onselectstart = function () { return false }
	}
	function removeDocumentEventHandlers() {
		document.onmousemove = document.onmouseup = document.ondragstart = document.body.onselectstart = null
	}


	return {

		makeDraggable: function (element) {
			element.onmousedown = mouseDown
		}
	}
}())