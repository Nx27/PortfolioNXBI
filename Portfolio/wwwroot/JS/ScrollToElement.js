window.scrollToElement = (id) => {
  const el = document.getElementById(id);
  const rect = el.getBoundingClientRect();
  const absoluteTop = rect.top + window.scrollY;

  // Calculate the offset (e.g., 0.25 = 1/4 of viewport height)
  const offset = window.innerHeight * 0.25;

  window.scrollTo({
    top: absoluteTop - offset,
    behavior: "smooth"
  });
};
