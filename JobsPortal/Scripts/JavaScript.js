﻿/* gator v1.2.2 craig.is/riding/gators */
(function () {
    function q(a, b, c) { if ("_root" == b) return c; if (a !== c) { var d; k || (a.matches && (k = a.matches), a.webkitMatchesSelector && (k = a.webkitMatchesSelector), a.mozMatchesSelector && (k = a.mozMatchesSelector), a.msMatchesSelector && (k = a.msMatchesSelector), a.oMatchesSelector && (k = a.oMatchesSelector), k || (k = e.matchesSelector)); d = k; if (d.call(a, b)) return a; if (a.parentNode) return m++ , q(a.parentNode, b, c) } } function s(a, b, c, e) { d[a.id] || (d[a.id] = {}); d[a.id][b] || (d[a.id][b] = {}); d[a.id][b][c] || (d[a.id][b][c] = []); d[a.id][b][c].push(e) }
    function t(a, b, c, e) { if (d[a.id]) if (!b) for (var f in d[a.id]) d[a.id].hasOwnProperty(f) && (d[a.id][f] = {}); else if (!e && !c) d[a.id][b] = {}; else if (!e) delete d[a.id][b][c]; else if (d[a.id][b][c]) for (f = 0; f < d[a.id][b][c].length; f++)if (d[a.id][b][c][f] === e) { d[a.id][b][c].splice(f, 1); break } } function u(a, b, c) {
        if (d[a][c]) {
            var k = b.target || b.srcElement, f, g, h = {}, n = g = 0; m = 0; for (f in d[a][c]) d[a][c].hasOwnProperty(f) && (g = q(k, f, l[a].element)) && e.matchesEvent(c, l[a].element, g, "_root" == f, b) && (m++ , d[a][c][f].match = g, h[m] = d[a][c][f]);
            b.stopPropagation = function () { b.cancelBubble = !0 }; for (g = 0; g <= m; g++)if (h[g]) for (n = 0; n < h[g].length; n++) { if (!1 === h[g][n].call(h[g].match, b)) { e.cancel(b); return } if (b.cancelBubble) return }
        }
    } function r(a, b, c, k) { function f(a) { return function (b) { u(g, b, a) } } if (this.element) { a instanceof Array || (a = [a]); c || "function" != typeof b || (c = b, b = "_root"); var g = this.id, h; for (h = 0; h < a.length; h++)k ? t(this, a[h], b, c) : (d[g] && d[g][a[h]] || e.addEvent(this, a[h], f(a[h])), s(this, a[h], b, c)); return this } } function e(a, b) {
        if (!(this instanceof
            e)) { for (var c in l) if (l[c].element === a) return l[c]; p++; l[p] = new e(a, p); return l[p] } this.element = a; this.id = b
    } var k, m = 0, p = 0, d = {}, l = {}; e.prototype.on = function (a, b, c) { return r.call(this, a, b, c) }; e.prototype.off = function (a, b, c) { return r.call(this, a, b, c, !0) }; e.matchesSelector = function () { }; e.cancel = function (a) { a.preventDefault(); a.stopPropagation() }; e.addEvent = function (a, b, c) { a.element.addEventListener(b, c, "blur" == b || "focus" == b) }; e.matchesEvent = function () { return !0 }; window.Gator = e
})();