function DragObject(element) {
    element.dragObject = this
    
    dragMaster.makeDraggable(element)

    var rememberPosition
    var mouseOffset

    this.onDragStart = function (offset) {
        var s = element.style
        rememberPosition = { top: s.top, left: s.left, position: s.position }
        s.position = 'absolute'

        mouseOffset = offset
    }

    this.hide = function () {
        element.style.display = 'none'
    }

    this.show = function () {
        element.style.display = ''
    }

    this.onDragMove = function (x, y) {
        element.style.top = y - mouseOffset.y + 'px'
        element.style.left = x - mouseOffset.x + 'px'
    }

    this.onDragSuccess = function (dropTarget) {
        //alert(element.innerHTML)
        //alert(dropTarget)
        var newHtml = ''
        var s = element.style
        var top = element.getBoundingClientRect().top;
        var in1 = element.innerHTML
        var res = []
        var els = document.getElementById(dropTarget).children
        //alert(top)
        check = 0
        for (var i = 0; i < els.length; i++) {
            var temp = els[i].getBoundingClientRect().top;
            var in2 = els[i].innerHTML;
            if (in2 == in1) {
                continue;
            }
            if (top <= (temp + 7) && check==0) {
                res.push(in1)
                res.push(els[i].innerHTML)
                check++
            }
            else {
                res.push(els[i].innerHTML)
            }


        }
        if (els.length > res.length) {
            res.push(in1)
        }
        alert(res)

        var list0 = document.getElementById(dropTarget)
        list0.innerHTML =''
        for (var i = 0; i < res.length; i++) {
            list0.innerHTML += '<div class="row border border-dark mt-1" style="max-height:max-content;">' + res[i] + '</div>'
        }
        document.location.reload();


    }

    this.onDragFail = function () {
        var s = element.style
        s.top = rememberPosition.top
        s.left = rememberPosition.left
        s.position = rememberPosition.position
    }

    this.toString = function () {
        return element.id
    }
}
