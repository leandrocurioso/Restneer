/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 50505
 Source Host           : localhost
 Source Database       : restneer

 Target Server Type    : MySQL
 Target Server Version : 50505
 File Encoding         : utf-8

 Date: 11/04/2018 20:04:02 PM
*/

SET NAMES utf8;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
--  Table structure for `api_resource`
-- ----------------------------
DROP TABLE IF EXISTS `api_resource`;
CREATE TABLE `api_resource` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `description` longtext NOT NULL,
  `uri` varchar(200) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `K_api_resource_key` (`name`,`uri`) USING BTREE,
  FULLTEXT KEY `FI_api_resource_description` (`description`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
--  Records of `api_resource`
-- ----------------------------
BEGIN;
INSERT INTO `api_resource` VALUES ('1', 'Api Resource Route', 'Api resource route', '/api-resource-route', '2018-10-11 19:41:41', null, null, '1'), ('2', 'Api User', 'Api user', '/api-user', '2018-11-01 00:00:00', null, null, '1');
COMMIT;

-- ----------------------------
--  Table structure for `api_resource_route`
-- ----------------------------
DROP TABLE IF EXISTS `api_resource_route`;
CREATE TABLE `api_resource_route` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `api_resource_id` bigint(20) unsigned NOT NULL,
  `name` varchar(200) NOT NULL,
  `description` longtext NOT NULL,
  `uri_pattern` varchar(300) NOT NULL,
  `is_logged` int(1) NOT NULL,
  `is_authenticated` int(1) NOT NULL,
  `version` varchar(3) NOT NULL,
  `http_verb` varchar(15) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `daleted_at` datetime DEFAULT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `K_api_resource_route_key` (`name`,`status`,`uri_pattern`,`version`,`http_verb`,`api_resource_id`) USING BTREE,
  FULLTEXT KEY `FI_api_resource_route_description` (`description`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
--  Records of `api_resource_route`
-- ----------------------------
BEGIN;
INSERT INTO `api_resource_route` VALUES ('1', '1', 'List', 'List all', '/', '0', '1', 'v1', 'GET', '2018-10-14 09:16:37', null, null, '1'), ('2', '2', 'Authenticate', 'Authenticate api user', '/authenticate', '1', '0', 'v1', 'POST', '2018-11-01 00:00:00', null, null, '1'), ('3', '2', 'Get', 'Get an user by id', '/{id:long}', '0', '1', 'v1', 'GET', '2018-11-01 00:00:00', null, null, '1');
COMMIT;

-- ----------------------------
--  Table structure for `api_role`
-- ----------------------------
DROP TABLE IF EXISTS `api_role`;
CREATE TABLE `api_role` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `description` longtext NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`,`name`),
  KEY `K_api_role_key` (`name`,`status`) USING BTREE,
  FULLTEXT KEY `FI_api_role_description` (`description`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
--  Records of `api_role`
-- ----------------------------
BEGIN;
INSERT INTO `api_role` VALUES ('1', 'Developer', 'The developer role.', '2018-09-16 16:14:19', null, null, '1'), ('2', 'User', 'The user role.', '2018-09-16 16:15:25', null, null, '1');
COMMIT;

-- ----------------------------
--  Table structure for `api_role_resource_route`
-- ----------------------------
DROP TABLE IF EXISTS `api_role_resource_route`;
CREATE TABLE `api_role_resource_route` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `api_role_id` bigint(20) unsigned NOT NULL,
  `api_resource_route_id` bigint(20) unsigned NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `K_api_role_resource_route_key` (`api_role_id`,`api_resource_route_id`,`status`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
--  Records of `api_role_resource_route`
-- ----------------------------
BEGIN;
INSERT INTO `api_role_resource_route` VALUES ('1', '1', '1', '2018-10-14 09:24:46', null, null, '1'), ('2', '1', '2', '2018-11-01 00:00:00', null, null, '1'), ('3', '1', '3', '2018-11-01 00:00:00', null, null, '1');
COMMIT;

-- ----------------------------
--  Table structure for `api_user`
-- ----------------------------
DROP TABLE IF EXISTS `api_user`;
CREATE TABLE `api_user` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `api_role_id` bigint(20) unsigned NOT NULL,
  `first_name` varchar(200) NOT NULL,
  `last_name` varchar(200) NOT NULL,
  `email` varchar(300) NOT NULL,
  `password` varchar(300) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`,`email`),
  KEY `K_api_user_api_role_id` (`api_role_id`) USING BTREE,
  KEY `K_api_user_key` (`email`,`password`,`status`) USING HASH
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
--  Records of `api_user`
-- ----------------------------
BEGIN;
INSERT INTO `api_user` VALUES ('1', '1', 'Leandro', 'Curioso', 'leandro.curioso@gmail.com', '134fe0751d14c37065a4a001a53de10d85d263e4dc42c00deba58e6133d97b6b', '2018-10-14 16:35:33', null, null, '1');
COMMIT;

SET FOREIGN_KEY_CHECKS = 1;
