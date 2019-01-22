/**
 * If arguments are equal
 * (hint: null != undefined)
 */
export function isEquivalent(a, b) {
    if (a === b) {
        return true;
    }
    if ((a == undefined && b != undefined) || (a != undefined && b == undefined)) {
        return false;
    }
    if (typeof a == typeof b) {
        if (typeof a == 'object') {
            let aProps = Object.getOwnPropertyNames(a);
            let bProps = Object.getOwnPropertyNames(b);
            if (aProps.length != bProps.length) {
                return false;
            }
            for (var i = 0; i < aProps.length; i++) {
                let propName = aProps[i];
                if (!isEquivalent(a[propName], b[propName])) {
                    return false;
                }
            }
            return true;
        } else {
            return a == b;
        }
    }
    return false;
}

export function isEmptyObject(obj) {
    if (obj == null || obj == undefined) {
        return true;
    }
    for(var prop in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, prop)) {
            return false;
        }
    }
    return true;
}


export function isNotBlank(str) {
    return str != undefined && str != null && str != false && str.toString().trim().length > 0;
}


export function isValidEmail(email) {
    let re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}