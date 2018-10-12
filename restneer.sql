/*
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
  KEY `K_api_resource_name_uri` (`name`,`uri`) USING BTREE,
  FULLTEXT KEY `FI_api_resource_description` (`description`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
--  Records of `api_resource`
-- ----------------------------
BEGIN;
INSERT INTO `api_resource` VALUES ('1', 'Api Resource Route', 'Api resource route', 'api-resource-route', '2018-10-11 19:41:41', null, null, '1');
COMMIT;

-- ----------------------------
--  Table structure for `api_resource_route`
-- ----------------------------
DROP TABLE IF EXISTS `api_resource_route`;
CREATE TABLE `api_resource_route` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `description` longtext NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `daleted_at` datetime DEFAULT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `K_api_resource_route_name_status` (`name`,`status`) USING BTREE,
  FULLTEXT KEY `FI_api_resource_route_description` (`description`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  KEY `K_api_role_name_status` (`name`,`status`) USING BTREE,
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
  KEY `K_api_role_resource_route_id` (`api_role_id`,`api_resource_route_id`,`status`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
--  Table structure for `api_user`
-- ----------------------------
DROP TABLE IF EXISTS `api_user`;
CREATE TABLE `api_user` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `email` varchar(250) NOT NULL,
  `first_name` varchar(200) NOT NULL,
  `last_name` varchar(200) NOT NULL,
  `password` varchar(500) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `deleted_at` datetime DEFAULT NULL,
  `status` int(11) NOT NULL,
  PRIMARY KEY (`id`,`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

SET FOREIGN_KEY_CHECKS = 1;
