$(".single-item-slide").slick({
  dots: true,
  infinite: true,
});

$(".multiple-items-slide").slick({
  infinite: true,
  slidesToShow: 3,
  slidesToScroll: 3,
  prevArrow: "<img src='/img/left_arrow.svg' class='prev' alt='1'>",
  nextArrow: "<img src='/img/right_arrow.svg' class='next' alt='2'>",
});
