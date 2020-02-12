'use strict';

var
	gulp = require('gulp'),
	concat = require('gulp-concat'),
	rename = require('gulp-rename'),
	uglifyCss = require('gulp-csso'),
	uglifyJs = require('gulp-uglify')
	;

function css(done) {
	gulp
		.src([
			'../shared/css/layout.css',
			'../shared/css/style_guide.css',
			'../page/about/css/style.css',
			'../page/booking/css/style.css',
			'../page/booking-in-process/css/style.css',
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
			'../shared/css/sweetalert2.css',
			'../shared/css/bootstrap.css'
		])
		.pipe(concat('style.css'))
		.pipe(gulp.dest('../../wwwroot/Content/css'))
		.pipe(rename('style.min.css'))
		.pipe(uglifyCss())
		.pipe(gulp.dest('../../wwwroot/Content/css'))
		;

	done();
}

function css_back(done) {
	gulp
		.src([
			'../shared/css/bootstrap.css',
			'../'
		])
		.pipe(concat('style_back.css'))
		.pipe(gulp.dest('../../wwwroot/Content/css'))
		.pipe(rename('style_back.min.css'))
		.pipe(uglifyCss())
		.pipe(gulp.dest('../../wwwroot/Content/css'))
		;

	done();
}

function font(done) {
	gulp
		.src([
			'../shared/fonts/**'
		])
		.pipe(gulp.dest('../../wwwroot/Content/fonts'))
		;

	done();
}

function img(done) {
	gulp
		.src([
			'../shared/img/**'
		])
		.pipe(gulp.dest('../../wwwroot/Content/img'))
		;

	done();
}

function svg(done) {
	gulp
		.src([
			'../shared/svg/**'
		])
		.pipe(gulp.dest('../../wwwroot/Content/svg'))
		;

	done();
}

function video(done) {
	gulp
		.src([
			'../shared/video/**'
		])
		.pipe(gulp.dest('../../wwwroot/Content/video'))
		;

	done();
}

function js(done) {
	gulp
		.src([
			'../shared/js/moment.min.js',
			'../shared/js/sweetalert2.all.js',
			'../shared/js/general-head.js',
			'../page/about/js/script.js',
			'../page/booking/js/script.js',
			'../page/booking-in-process/js/script.js',
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
			'../shared/js/general-tail.js'
		])
		.pipe(concat('script.js'))
		.pipe(gulp.dest('../../wwwroot/Content/js'))
		.pipe(rename('script.min.js'))
		.pipe(uglifyJs())
		.pipe(gulp.dest('../../wwwroot/Content/js'))
		;

	done();
}

function js_back(done) {
	gulp
		.src([
			'../shared/js/moment.min.js',
			'../shared/js/sweetalert2.all.js',
			'../shared/js/jquery.js',
			'../page/clientsCRUD/js/script.js'
		])
		.pipe(concat('script_back.js'))
		.pipe(gulp.dest('../../wwwroot/Content/js'))
		.pipe(rename('script_back.min.js'))
		.pipe(uglifyJs())
		.pipe(gulp.dest('../../wwwroot/Content/js'))
		;

	done();
}

exports.default = gulp.parallel(css, css_back, font, img, svg, video, js, js_back);
