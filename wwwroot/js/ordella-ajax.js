// Ordella AJAX helper: GET requests return JSON; POST requests send JSON and antiforgery token.
window.ordellaAjax = {
  async get(url) { const response = await fetch(url, { headers: { Accept: 'application/json' } }); if (!response.ok) throw new Error(`Request failed (${response.status})`); return response.json(); },
  async post(url, payload, token) { const response = await fetch(url, { method: 'POST', headers: { 'Content-Type': 'application/json', 'RequestVerificationToken': token }, body: JSON.stringify(payload) }); if (!response.ok) throw new Error(`Request failed (${response.status})`); return response.json(); }
};
