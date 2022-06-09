let email = document.getElementById('email')
let senha = document.getElementById('senha')
let span = document.getElementById('erro')
let form = document.getElementById('login')

form.addEventListener('submit', (e) => {
    if (email.value === '' || email.value == null) {
        e.preventDefault()
        span.removeAttribute("hidden")
    } else if (senha.value === '' || senha.value == null) {
        e.preventDefault()
        span.removeAttribute("hidden")
    }
})