'use strict';

var
	gulp = require('gulp'),
	concat = require('gulp-concat'),
	rename = require('gulp-rename'),
	uglifyCss = require('gulp-csso'),
	uglifyJs = require('gulp-uglify-es').default
	;

function css(done) {
	gulp
		.src([
			'../shared/css/layout.css',
			'../shared/css/style_guide.css',
			'../page/about/css/style.css',
			'../page/booking/css/style.css',
			'../page/bookingInProcess/css/style.css',
			'../page/bookingCompleted/css/style.css',
			'../page/contact/css/style.css',
			'../page/cookieUsage/css/style.css',
			'../page/hotel/css/style.css',
			'../page/index/css/style.css',
			'../page/personalDataUsage/css/style.css',
			'../page/room/css/style.css',
			'../page/search/css/style.css',
			'../page/thanksForContactingUs/css/style.css',
			'../page/thanksForSubscribing/css/style.css',
			'../page/notFound/css/style.css',
			'../shared/css/sweetalert2.css'
		])
		.pipe(concat('style.css'))
		.pipe(gulp.dest('../../Content/css'))
		.pipe(rename('style.min.css'))
		.pipe(uglifyCss())
		.pipe(gulp.dest('../../Content/css'))
		;

	done();
}

function css_back(done) {
	gulp
		.src([
			'../shared/css/bootstrap.css',
			'../shared/css/layout_back.css'
		])
		.pipe(concat('style_back.css'))
		.pipe(gulp.dest('../../Content/css'))
		.pipe(rename('style_back.min.css'))
		.pipe(uglifyCss())
		.pipe(gulp.dest('../../Content/css'))
		;

	done();
}

function font(done) {
	gulp
		.src([
			'../shared/fonts/**'
		])
		.pipe(gulp.dest('../../Content/fonts'))
		;

	done();
}

function img(done) {
	gulp
		.src([
			'../shared/img/**'
		])
		.pipe(gulp.dest('../../Content/img'))
		;

	done();
}

function svg(done) {
	gulp
		.src([
			'../shared/svg/**'
		])
		.pipe(gulp.dest('../../Content/svg'))
		;

	done();
}

function video(done) {
	gulp
		.src([
			'../shared/video/**'
		])
		.pipe(gulp.dest('../../Content/video'))
		;

	done();
}

function js(done) {
	gulp
		.src([
			'../shared/js/moment.js',
			'../shared/js/sweetalert2.all.js',
			'../shared/js/general-head.js',
			'../shared/js/Filters.js',
			'../shared/js/Searcher.js',
			'../page/about/js/script.js',
			'../page/booking/js/script.js',
			'../page/bookingInProcess/js/script.js',
			'../page/bookingCompleted/js/script.js',
			'../page/contact/js/script.js',
			'../page/cookieUsage/js/script.js',
			'../page/hotel/js/script.js',
			'../page/index/js/script.js',
			'../page/personalDataUsage/js/script.js',
			'../page/room/js/script.js',
			'../page/search/js/script.js',
			'../page/thanksForContactingUs/js/script.js',
			'../page/thanksForSubscribing/js/script.js',
			'../page/notFound/js/script.js',
			'../shared/js/general-tail.js'
		])
		.pipe(concat('script.js'))
		.pipe(gulp.dest('../../Content/js'))
		.pipe(rename('script.min.js'))
		.pipe(uglifyJs())
		.pipe(gulp.dest('../../Content/js'))
		;

	done();
}

function js_back(done) {
	gulp
		.src([
			'../shared/js/moment.js',
			'../shared/js/sweetalert2.all.js',
			'../shared/js/jquery.js',
			'../page/clientsCRUD/js/script.js'
		])
		.pipe(concat('script_back.js'))
		.pipe(gulp.dest('../../Content/js'))
		.pipe(rename('script_back.min.js'))
		.pipe(uglifyJs())
		.pipe(gulp.dest('../../Content/js'))
		;

	done();
}

exports.default = gulp.parallel(css, css_back, font, img, svg, video, js, js_back);