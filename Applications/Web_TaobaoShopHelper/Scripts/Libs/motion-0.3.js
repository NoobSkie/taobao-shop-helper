// vim: set et sw=4 ts=4 sts=4 fdm=marker ff=unix fenc=utf8
/**
 * Motion - 动画组件
 *
 * @author  mingcheng<i.feelinglucky@gmail.com>
 * @since   2009-01-26
 * @link    http://www.gracecode.com/
 * @version $Id: motion.js 228 2009-04-14 06:30:12Z i.feelinglucky $
 *
 * @change
 *     [+]new feature  [*]improvement  [!]change  [x]bug fix
 *
 * [x] 2009-04-14
 *      修复因原型继承造成多个实例动画混乱的问题
 *
 * [+] 2009-04-14
 *      增加回调作用域，方便链式操作
 *
 * [+] 2009-04-08
 *      增加暂停、继续动画
 *
 * [*] 2009-04-07
 *      组织变量，更名 customEvent 为 _callback
 *
 * [*] 2009-04-07
 *      优化代码组织，改回 setInterval 为 setTimeout，详见 http://lifesinger.org/blog/?p=1184
 *
 * [*] 2009-04-05
 *      优化对象接口
 *
 * [*] 2009-04-03
 *      优化 customEvent；增强动画函数判断，使其支持自定义函数
 *
 * [*] 2009-03-30
 *      增加 customEvent 函数，优化逻辑
 *
 * [!] 2009-02-01
 *      将 setTimeout 改成了 setInterval ，详见 http://ejohn.org/blog/how-javascript-timers-work/
 *
 * [*] 2009-01-27
 *      调整接口，优化代码
 *
 * [+] 2009-01-26
 *      最初版，完成基本功能
 */
(function(scope) {
    /**
     * Easing Equations
     *
     * @see http://developer.yahoo.com/yui/animation/
     * @see http://www.robertpenner.com/profmx
     * @see http://hikejun.com/demo/yui-base/yui_2x_animation.html
     */
    var Tween = {
        linear: function (t, b, c, d) {
            return c*t/d + b;
        },

        easeIn: function (t, b, c, d) {
            return c*(t/=d)*t + b;
        },

        easeOut: function (t, b, c, d) {
            return -c *(t/=d)*(t-2) + b;
        },

        easeBoth: function (t, b, c, d) {
            if ((t/=d/2) < 1) {
                return c/2*t*t + b;
            }
            return -c/2 * ((--t)*(t-2) - 1) + b;
        },
        
        easeInStrong: function (t, b, c, d) {
            return c*(t/=d)*t*t*t + b;
        },
        
        easeOutStrong: function (t, b, c, d) {
            return -c * ((t=t/d-1)*t*t*t - 1) + b;
        },
        
        easeBothStrong: function (t, b, c, d) {
            if ((t/=d/2) < 1) {
                return c/2*t*t*t*t + b;
            }
            return -c/2 * ((t-=2)*t*t*t - 2) + b;
        },

        elasticIn: function (t, b, c, d, a, p) {
            if (t === 0) { 
                return b; 
            }
            if ( (t /= d) == 1 ) {
                return b+c; 
            }
            if (!p) {
                p=d*0.3; 
            }
            if (!a || a < Math.abs(c)) {
                a = c; 
                var s = p/4;
            } else {
                var s = p/(2*Math.PI) * Math.asin (c/a);
            }
            return -(a*Math.pow(2,10*(t-=1)) * Math.sin( (t*d-s)*(2*Math.PI)/p )) + b;
        },

        elasticOut: function (t, b, c, d, a, p) {
            if (t === 0) {
                return b;
            }
            if ( (t /= d) == 1 ) {
                return b+c;
            }
            if (!p) {
                p=d*0.3;
            }
            if (!a || a < Math.abs(c)) {
                a = c;
                var s = p / 4;
            } else {
                var s = p/(2*Math.PI) * Math.asin (c/a);
            }
            return a*Math.pow(2,-10*t) * Math.sin( (t*d-s)*(2*Math.PI)/p ) + c + b;
        },
        
        elasticBoth: function (t, b, c, d, a, p) {
            if (t === 0) {
                return b;
            }
            if ( (t /= d/2) == 2 ) {
                return b+c;
            }
            if (!p) {
                p = d*(0.3*1.5);
            }
            if ( !a || a < Math.abs(c) ) {
                a = c; 
                var s = p/4;
            }
            else {
                var s = p/(2*Math.PI) * Math.asin (c/a);
            }
            if (t < 1) {
                return - 0.5*(a*Math.pow(2,10*(t-=1)) * 
                        Math.sin( (t*d-s)*(2*Math.PI)/p )) + b;
            }
            return a*Math.pow(2,-10*(t-=1)) * 
                    Math.sin( (t*d-s)*(2*Math.PI)/p )*0.5 + c + b;
        },

        backIn: function (t, b, c, d, s) {
            if (typeof s == 'undefined') {
               s = 1.70158;
            }
            return c*(t/=d)*t*((s+1)*t - s) + b;
        },

        backOut: function (t, b, c, d, s) {
            if (typeof s == 'undefined') {
                s = 1.70158;
            }
            return c*((t=t/d-1)*t*((s+1)*t + s) + 1) + b;
        },
        
        backBoth: function (t, b, c, d, s) {
            if (typeof s == 'undefined') {
                s = 1.70158; 
            }
            if ((t /= d/2 ) < 1) {
                return c/2*(t*t*(((s*=(1.525))+1)*t - s)) + b;
            }
            return c/2*((t-=2)*t*(((s*=(1.525))+1)*t + s) + 2) + b;
        },

        bounceIn: function (t, b, c, d) {
            return c - Tween['bounceOut'](d-t, 0, c, d) + b;
        },
        
        bounceOut: function (t, b, c, d) {
            if ((t/=d) < (1/2.75)) {
                return c*(7.5625*t*t) + b;
            } else if (t < (2/2.75)) {
                return c*(7.5625*(t-=(1.5/2.75))*t + 0.75) + b;
            } else if (t < (2.5/2.75)) {
                return c*(7.5625*(t-=(2.25/2.75))*t + 0.9375) + b;
            }
            return c*(7.5625*(t-=(2.625/2.75))*t + 0.984375) + b;
        },
        
        bounceBoth: function (t, b, c, d) {
            if (t < d/2) {
                return Tween['bounceIn'](t*2, 0, c, d) * 0.5 + b;
            }
            return Tween['bounceOut'](t*2-d, 0, c, d) * 0.5 + c*0.5 + b;
        }
    };

    /**
     * 动画组件
     *
     * @params {String} 动画类型（方程式）
     * @params {Number} 过程动画时间
     */
    scope.Motion = function(tween, duration) {
        this.duration = duration || 1000;
        this.tween = tween || 'linear';
    };

    // 返回动画公式
    scope.Motion.getTweens = function(){
        return Tween
    };

    /**
     * 运行间隔，回调作用域
     */
    var _interval = 50;

    // 原型继承
    scope.Motion.prototype = (function() {
        /**
         * 执行回调
         * 
         * @params {Function} 事件回调
         * @params {Object} 作用域
         */
        var _callback = function(func, scope) {
            var args = Array.prototype.slice.call(arguments).slice(2);
            if (typeof func == 'function') {
                try {
                    return func.apply(scope || this, args);
                } catch (e) {
                    scope.errors = scope.errors || [];
                    scope.errors.push(e);
                }
            }
        };

        /**
         * 动画行进中
         *
         * @return {void}
         */
        var _Tweening = function() {
            // 动画进行时的回调
            _callback(this.onTweening, this);

            // 如果运行帧数大于实际计算帧数，说明动画运行完成
            if (this.current >= this.frames) {
                // 停止动画
                this.stop();

                // 动画结束时的回调
                return _callback(this.onComplete, this) || this;
            } else {
                // 计算运行帧数
                ++this.current;

                // 继续运行下一帧动画
                var f = arguments.callee, _self = this;
                this.timer = setTimeout(function() {f.call(_self)}, _interval);
            }
        };
      
        /**
         * 公共方法
         */
        return {
            /**
             * 初始化
             */
            init: function() {
                // 默认 35 FPS
                this.fps = this.fps || 35;

                // 计算帧数
                this.frames = Math.ceil((this.duration/1000)*this.fps);

                // 保证最小帧数
                if (this.frames < 1) this.frames = 1;

                // 动画公式，调用方式 this.equation
                var f = ('function' == typeof this.tween) ? this.tween : Tween[this.tween] || Tween['linear'];
                this.equation = function(from, to) {
                    return f((this.current/this.frames)*this.duration, from, to - from, this.duration);
                };

                // 计算运行间隔
                _interval = this.duration / this.frames;

                // 初始化时的回调
                _callback(this.onInit, this);
            },

            /**
             * 开始动画
             */
            start: function(force) {
                // 如果不是在暂停状态，则执行初始化操作
                if (!this.paused) {
                    // 默认初始化
                    this.init();

                    // 初始化运行帧数
                    this.current = 1;

                    // 动画开始时的回调
                    _callback(this.onStart, this);
                }

                // 执行动画
                var _self = this;
                this.timer = setTimeout(function() {_Tweening.call(_self);}, _interval);

                // 返回自身
                return this;
            },

            // 停止动画
            stop: function() {
                clearTimeout(this.timer);
            },

            // 暂停动画
            sleep: function() {
                // 停止动画
                this.stop();

                // 暂停状态
                this.paused = true;

                // 暂停动画时的回调
                return _callback(this.onSleep, this) || this;
            },

            // 继续动画
            wakeup: function() {
                // 恢复动画
                this.start();

                // 暂停状态
                this.paused = false;

                // 继续动画时的回调
                return _callback(this.onWakeup, this) || this;
            }
        };
    })();
})(window);
