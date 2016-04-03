/*
Navicat MySQL Data Transfer

Source Server         : localMysql
Source Server Version : 50627
Source Host           : localhost:3306
Source Database       : wproject

Target Server Type    : MYSQL
Target Server Version : 50627
File Encoding         : 65001

Date: 2015-10-25 11:09:42
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for access
-- ----------------------------
DROP TABLE IF EXISTS `access`;
CREATE TABLE `access` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `group_id` int(11) DEFAULT NULL,
  `access_id` int(11) NOT NULL,
  `read` tinyint(4) DEFAULT NULL,
  `add` tinyint(4) DEFAULT NULL,
  `edit` tinyint(4) DEFAULT NULL,
  `delete` tinyint(4) DEFAULT NULL,
  `access_granted_at` datetime DEFAULT NULL,
  `access_granted_by` int(11) DEFAULT NULL,
  `object_id` int(11) DEFAULT NULL,
  `comment` text,
  `metadata` text,
  `deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `access_object_user_FK_user_id` (`user_id`),
  KEY `access_object_group_FK_group_id` (`group_id`),
  KEY `access_object_user_FK_access_granted_by` (`access_granted_by`),
  KEY `access_object_access_FK_access_id` (`access_id`),
  CONSTRAINT `access_object_access_FK_access_id` FOREIGN KEY (`access_id`) REFERENCES `access_object` (`id`),
  CONSTRAINT `access_object_group_FK_group_id` FOREIGN KEY (`group_id`) REFERENCES `group` (`id`),
  CONSTRAINT `access_object_user_FK_access_granted_by` FOREIGN KEY (`access_granted_by`) REFERENCES `user` (`id`),
  CONSTRAINT `access_object_user_FK_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for access_object
-- ----------------------------
DROP TABLE IF EXISTS `access_object`;
CREATE TABLE `access_object` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(1024) NOT NULL,
  `code` varchar(1024) NOT NULL,
  `metadata` text,
  `deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for active_session
-- ----------------------------
DROP TABLE IF EXISTS `active_session`;
CREATE TABLE `active_session` (
  `id` int(11) NOT NULL,
  `created_at` datetime NOT NULL,
  `uid` varchar(512) DEFAULT NULL,
  `user_id` int(11) NOT NULL,
  `last_heart_beat` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `ip` varchar(128) DEFAULT NULL,
  `context_id` varchar(512) DEFAULT NULL,
  `metadata` text,
  PRIMARY KEY (`id`),
  KEY `active_session_user_FK_user_id` (`user_id`),
  CONSTRAINT `active_session_user_FK_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for app_setting
-- ----------------------------
DROP TABLE IF EXISTS `app_setting`;
CREATE TABLE `app_setting` (
  `id` int(11) NOT NULL,
  `key` varchar(128) NOT NULL,
  `value` text NOT NULL,
  `last_updated_at` datetime DEFAULT NULL,
  `last_updated_by` int(11) DEFAULT NULL,
  `comment` text,
  `metadata` text,
  `deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `app_setting_UNQ_key` (`key`) USING BTREE,
  KEY `app_setting_user_FK_last_updated_by` (`last_updated_by`) USING BTREE,
  CONSTRAINT `app_setting_user_FK_last_updated_by` FOREIGN KEY (`last_updated_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for backlog
-- ----------------------------
DROP TABLE IF EXISTS `backlog`;
CREATE TABLE `backlog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL,
  `created_by` int(11) NOT NULL,
  `assigned_to` int(11) DEFAULT NULL,
  `state_id` int(11) NOT NULL,
  `type_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `priority` int(11) DEFAULT NULL,
  `period_from` datetime DEFAULT NULL,
  `period_to` datetime DEFAULT NULL,
  `remaining_work` int(11) DEFAULT NULL COMMENT 'in minutes',
  `description` longtext,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `backlog_dict_item_FK_state_id` (`state_id`),
  KEY `backlog_dict_item_FK_type_id` (`type_id`),
  KEY `backlog_category_FK_category_id` (`category_id`),
  KEY `backlog_user_FK_created_by` (`created_by`),
  KEY `backlog_user_FK_assigned_to` (`assigned_to`),
  CONSTRAINT `backlog_category_FK_category_id` FOREIGN KEY (`category_id`) REFERENCES `category` (`id`),
  CONSTRAINT `backlog_dict_item_FK_state_id` FOREIGN KEY (`state_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `backlog_dict_item_FK_type_id` FOREIGN KEY (`type_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `backlog_user_FK_assigned_to` FOREIGN KEY (`assigned_to`) REFERENCES `user` (`id`),
  CONSTRAINT `backlog_user_FK_created_by` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` text,
  `created_at` datetime NOT NULL,
  `created_by` int(11) NOT NULL,
  `owner_id` int(11) NOT NULL,
  `period_from` datetime DEFAULT NULL,
  `period_to` datetime DEFAULT NULL,
  `spring_id` int(11) NOT NULL,
  `parent_id` int(11) DEFAULT NULL,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `spring_project_FK_project_id` (`spring_id`),
  KEY `category_category_FK_parent_id` (`parent_id`),
  KEY `category_user_FK_created_by` (`created_by`),
  KEY `category_user_FK_owner_id` (`owner_id`),
  CONSTRAINT `category_category_FK_parent_id` FOREIGN KEY (`parent_id`) REFERENCES `category` (`id`),
  CONSTRAINT `category_spring_FK_spring_id` FOREIGN KEY (`spring_id`) REFERENCES `spring` (`id`),
  CONSTRAINT `category_user_FK_created_by` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`),
  CONSTRAINT `category_user_FK_owner_id` FOREIGN KEY (`owner_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dict_item
-- ----------------------------
DROP TABLE IF EXISTS `dict_item`;
CREATE TABLE `dict_item` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(512) NOT NULL,
  `description` text,
  `type` varchar(128) NOT NULL,
  `parent_id` int(11) DEFAULT NULL,
  `reserved` tinyint(1) DEFAULT NULL,
  `code` varchar(64) DEFAULT NULL,
  `order` int(11) DEFAULT NULL,
  `color` varchar(16) DEFAULT NULL,
  `tag` text,
  `deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `dict_item _dict_item_FK_parent_id` (`parent_id`),
  CONSTRAINT `dict_item _dict_item_FK_parent_id` FOREIGN KEY (`parent_id`) REFERENCES `dict_item` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for file
-- ----------------------------
DROP TABLE IF EXISTS `file`;
CREATE TABLE `file` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(1024) NOT NULL,
  `type` varchar(128) DEFAULT NULL,
  `content` longblob NOT NULL,
  `thumbnail` longblob,
  `size` bigint(20) DEFAULT NULL,
  `parent_type` varchar(128) DEFAULT NULL,
  `parent_id` int(11) DEFAULT NULL,
  `metadata` text,
  `path` mediumtext,
  `url` mediumtext,
  `created_at` datetime DEFAULT NULL,
  `created_by` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `file_user_FK_created_by` (`created_by`),
  CONSTRAINT `file_user_FK_created_by` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for group
-- ----------------------------
DROP TABLE IF EXISTS `group`;
CREATE TABLE `group` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` text,
  `created` datetime NOT NULL,
  `owner_id` int(11) NOT NULL,
  `deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `group_user_FK_owner_id` (`owner_id`),
  CONSTRAINT `group_user_FK_owner_id` FOREIGN KEY (`owner_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for log
-- ----------------------------
DROP TABLE IF EXISTS `log`;
CREATE TABLE `log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime(6) DEFAULT NULL,
  `entry_type` tinyint(4) DEFAULT NULL,
  `ip` varchar(128) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `access_object_id` int(11) DEFAULT NULL,
  `action` tinyint(4) DEFAULT NULL,
  `details` text,
  `metadata` text,
  `important` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `log_user_FK_user_id` (`user_id`),
  KEY `log_access_object_FK_access_object_id` (`access_object_id`),
  CONSTRAINT `log_access_object_FK_access_object_id` FOREIGN KEY (`access_object_id`) REFERENCES `access_object` (`id`),
  CONSTRAINT `log_user_FK_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for project
-- ----------------------------
DROP TABLE IF EXISTS `project`;
CREATE TABLE `project` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` text,
  `created_at` datetime NOT NULL,
  `created_by` int(11) NOT NULL,
  `owner_id` int(11) NOT NULL,
  `period_from` datetime DEFAULT NULL,
  `period_to` datetime DEFAULT NULL,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `project_user_FK_created_by` (`created_by`),
  KEY `project_user_FK_owner_id` (`owner_id`),
  CONSTRAINT `project_user_FK_created_by` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`),
  CONSTRAINT `project_user_FK_owner_id` FOREIGN KEY (`owner_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for project_setting
-- ----------------------------
DROP TABLE IF EXISTS `project_setting`;
CREATE TABLE `project_setting` (
  `id` int(11) NOT NULL,
  `project_id` int(11) NOT NULL,
  `key` varchar(128) NOT NULL,
  `value` text NOT NULL,
  `last_updated_at` datetime DEFAULT NULL,
  `last_updated_by` int(11) DEFAULT NULL,
  `comments` text,
  `metadata` text,
  `deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `project_setting_UNQ_key_project_id` (`project_id`,`key`),
  KEY `project_setting_user_FK_last_updated_by` (`last_updated_by`),
  CONSTRAINT `project_setting_project_FK_project_id` FOREIGN KEY (`project_id`) REFERENCES `project` (`id`),
  CONSTRAINT `project_setting_user_FK_last_updated_by` FOREIGN KEY (`last_updated_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for spring
-- ----------------------------
DROP TABLE IF EXISTS `spring`;
CREATE TABLE `spring` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` text,
  `created_at` datetime NOT NULL,
  `created_by` int(11) NOT NULL,
  `owner_id` int(11) NOT NULL,
  `period_from` datetime DEFAULT NULL,
  `period_to` datetime DEFAULT NULL,
  `project_id` int(11) NOT NULL,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `spring_project_FK_project_id` (`project_id`),
  KEY `spring_user_FK_created_by` (`created_by`),
  KEY `spring_user_FK_owner_id` (`owner_id`),
  CONSTRAINT `spring_project_FK_project_id` FOREIGN KEY (`project_id`) REFERENCES `project` (`id`),
  CONSTRAINT `spring_user_FK_created_by` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`),
  CONSTRAINT `spring_user_FK_owner_id` FOREIGN KEY (`owner_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for task
-- ----------------------------
DROP TABLE IF EXISTS `task`;
CREATE TABLE `task` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL,
  `created_by` int(11) NOT NULL,
  `assigned_to` int(11) DEFAULT NULL,
  `state_id` int(11) NOT NULL,
  `type_id` int(11) NOT NULL,
  `stage_id` int(11) DEFAULT NULL,
  `backlog_id` int(11) NOT NULL,
  `priority` int(11) DEFAULT NULL,
  `period_from` datetime DEFAULT NULL,
  `period_to` datetime DEFAULT NULL,
  `remaining_work` int(11) DEFAULT NULL COMMENT 'in minutes',
  `description` longtext NOT NULL,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `task_dict_item_FK_state_id` (`state_id`),
  KEY `task_dict_item_FK_type_id` (`type_id`),
  KEY `task_dict_item_FK_stage_id` (`stage_id`),
  KEY `task_backlog_FK_backlog_id` (`backlog_id`),
  KEY `task_user_FK_created_by` (`created_by`),
  KEY `task_user_FK_assigned_to` (`assigned_to`),
  CONSTRAINT `task_backlog_FK_backlog_id` FOREIGN KEY (`backlog_id`) REFERENCES `backlog` (`id`),
  CONSTRAINT `task_dict_item_FK_stage_id` FOREIGN KEY (`stage_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `task_dict_item_FK_state_id` FOREIGN KEY (`state_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `task_dict_item_FK_type_id` FOREIGN KEY (`type_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `task_user_FK_assigned_to` FOREIGN KEY (`assigned_to`) REFERENCES `user` (`id`),
  CONSTRAINT `task_user_FK_created_by` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for task_attachement
-- ----------------------------
DROP TABLE IF EXISTS `task_attachement`;
CREATE TABLE `task_attachement` (
  `id` int(11) NOT NULL,
  `task_id` int(11) NOT NULL,
  `file_id` int(11) NOT NULL,
  `attached_at` datetime NOT NULL,
  `attached_by` int(11) NOT NULL,
  `comments` text,
  `metadata` text,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `task_attachement_task_FK_task_id` (`task_id`),
  KEY `task_attachement_user_FK_attached_by` (`attached_by`),
  KEY `task_attachement_file_FK_file_id` (`file_id`),
  CONSTRAINT `task_attachement_file_FK_file_id` FOREIGN KEY (`file_id`) REFERENCES `file` (`id`),
  CONSTRAINT `task_attachement_task_FK_task_id` FOREIGN KEY (`task_id`) REFERENCES `task` (`id`),
  CONSTRAINT `task_attachement_user_FK_attached_by` FOREIGN KEY (`attached_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for task_dependency
-- ----------------------------
DROP TABLE IF EXISTS `task_dependency`;
CREATE TABLE `task_dependency` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `task_id` int(11) NOT NULL,
  `task_dependent_id` int(11) NOT NULL,
  `dependent_state_id` int(11) DEFAULT NULL,
  `dependent_stage_id` int(11) DEFAULT NULL,
  `block_on_state_id` int(11) DEFAULT NULL,
  `block_on_stage_id` int(11) DEFAULT NULL,
  `created_at` date NOT NULL,
  `created_by` int(11) NOT NULL,
  `comments` text,
  `metadata` text,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `task_dependency_task_FK_task_id` (`task_id`),
  KEY `task_dependency_task_FK_task_dependent_id` (`task_dependent_id`),
  KEY `task_dependency_dict_item_FK_dependent_state_id` (`dependent_state_id`),
  KEY `task_dependency_dict_item_FK_dependent_stage_id` (`dependent_stage_id`),
  KEY `task_dependency_dict_item_FK_block_on_state_id` (`block_on_state_id`),
  KEY `task_dependency_dict_item_FK_block_on_stage_id` (`block_on_stage_id`),
  KEY `task_dependency_users_FK_created_by` (`created_by`),
  CONSTRAINT `task_dependency_dict_item_FK_block_on_stage_id` FOREIGN KEY (`block_on_stage_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `task_dependency_dict_item_FK_block_on_state_id` FOREIGN KEY (`block_on_state_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `task_dependency_dict_item_FK_dependent_stage_id` FOREIGN KEY (`dependent_stage_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `task_dependency_dict_item_FK_dependent_state_id` FOREIGN KEY (`dependent_state_id`) REFERENCES `dict_item` (`id`),
  CONSTRAINT `task_dependency_task_FK_task_dependent_id` FOREIGN KEY (`task_dependent_id`) REFERENCES `task` (`id`),
  CONSTRAINT `task_dependency_task_FK_task_id` FOREIGN KEY (`task_id`) REFERENCES `task` (`id`),
  CONSTRAINT `task_dependency_users_FK_created_by` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for task_history
-- ----------------------------
DROP TABLE IF EXISTS `task_history`;
CREATE TABLE `task_history` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `task_id` int(11) NOT NULL,
  `updated_at` datetime NOT NULL,
  `updated_by` int(11) NOT NULL,
  `field_name` varchar(255) NOT NULL,
  `field_old_value` longtext,
  `field_new_value` longtext NOT NULL,
  `comments` text,
  `metadata` text,
  `deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `task_history_task_FK_task_id` (`task_id`),
  KEY `task_history_user_FK_updated_by` (`updated_by`),
  CONSTRAINT `task_history_task_FK_task_id` FOREIGN KEY (`task_id`) REFERENCES `task` (`id`),
  CONSTRAINT `task_history_user_FK_updated_by` FOREIGN KEY (`updated_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for task_tag
-- ----------------------------
DROP TABLE IF EXISTS `task_tag`;
CREATE TABLE `task_tag` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `task_id` int(11) NOT NULL,
  `text` varchar(512) NOT NULL,
  `created_at` datetime NOT NULL,
  `created_by` int(11) NOT NULL,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `task_tag_task_FK_task_id` (`task_id`),
  KEY `task_tag_user_FK_created_by` (`created_by`),
  CONSTRAINT `task_tag_task_FK_task_id` FOREIGN KEY (`task_id`) REFERENCES `task` (`id`),
  CONSTRAINT `task_tag_user_FK_created_by` FOREIGN KEY (`created_by`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) NOT NULL,
  `email` varchar(128) DEFAULT NULL,
  `login` varchar(128) NOT NULL,
  `word` varchar(512) NOT NULL,
  `expire` datetime DEFAULT NULL,
  `su` tinyint(4) DEFAULT NULL,
  `suspended` tinyint(1) DEFAULT NULL,
  `deleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for user_in_group
-- ----------------------------
DROP TABLE IF EXISTS `user_in_group`;
CREATE TABLE `user_in_group` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `group_id` int(11) NOT NULL,
  `added` datetime NOT NULL,
  `added_by` int(11) DEFAULT NULL,
  `comments` text,
  `metadata` text,
  `deleted` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`,`user_id`,`group_id`),
  KEY `user_in_group_user_FK_user_id` (`user_id`),
  KEY `user_in_group_user_FK_group_id` (`group_id`),
  KEY `user_in_group_user_FK_added_by` (`added_by`),
  CONSTRAINT `user_in_group_user_FK_added_by` FOREIGN KEY (`added_by`) REFERENCES `user` (`id`),
  CONSTRAINT `user_in_group_user_FK_group_id` FOREIGN KEY (`group_id`) REFERENCES `group` (`id`),
  CONSTRAINT `user_in_group_user_FK_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
