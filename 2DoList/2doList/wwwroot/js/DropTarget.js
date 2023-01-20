function DropTarget(element) {

	element.dropTarget = this

	this.canAccept = function (dragObject) {
		return true
	}

	this.accept = function (dragObject) {
		
		this.onLeave(dragObject)

		//dragObject.hide()

		//alert("Акцептор '" + this + "': принял объект '" + dragObject + "'")
	}

	this.onLeave = function (obj) {
		
		element.className = ''
	}

	this.onEnter = function () {
		element.className = 'uponMe'
	}

	this.toString = function () {
		return element.id
	}
}