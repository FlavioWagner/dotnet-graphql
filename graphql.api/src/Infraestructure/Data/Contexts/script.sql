create database dbgraphql; 

CREATE SEQUENCE public.pessoa_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;

CREATE SEQUENCE public.ramo_juridica_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;

CREATE SEQUENCE public.ramo_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
	
CREATE TABLE public.pessoa (
	id int8 NOT NULL DEFAULT nextval('pessoa_seq'::regclass),
	nome varchar(100) NOT NULL,
	registro varchar(25) NOT NULL,
	data_cadastro timestamp NULL DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT pk_pessoa PRIMARY KEY (id)
);

CREATE TABLE public.ramo (
	id int8 NOT NULL DEFAULT nextval('ramo_seq'::regclass),
	nome varchar(100) NOT NULL,
	CONSTRAINT pk_ramo PRIMARY KEY (id)
);

CREATE TABLE public.pessoa_fisica (
	id int8 NOT NULL,
	data_nascimento date NULL,
	rg varchar(10) NULL,
	rg_expedidor varchar(50) NULL,
	rg_expedicao date NULL,
	titulo varchar(10) NULL,
	titulo_zona varchar(5) NULL,
	titulo_secao varchar(5) NULL,
	nome_mae varchar(50) NULL,
	nome_pai varchar(50) NULL,
	CONSTRAINT pk_pessoa_fisica PRIMARY KEY (id),
	CONSTRAINT fk_pessoa_fisica_pessoa FOREIGN KEY (id) REFERENCES public.pessoa(id)
);

CREATE TABLE public.pessoa_juridica (
	id int8 NOT NULL,
	nome_fantasia varchar(100) NULL,
	CONSTRAINT pk_pessoa_juridica PRIMARY KEY (id),
	CONSTRAINT fk_pessoa_juridica_pessoa FOREIGN KEY (id) REFERENCES public.pessoa(id)
);

CREATE TABLE public.ramo_juridica (
	id int8 NOT NULL DEFAULT nextval('ramo_juridica_seq'::regclass),
	id_pessoa_juridica int8 NOT NULL,
	id_ramo int8 NOT NULL,
	CONSTRAINT pk_ramo_juridica PRIMARY KEY (id),
	CONSTRAINT uk_ramo_juridica UNIQUE (id_pessoa_juridica, id_ramo),
	CONSTRAINT fk_ramo_juridica_pessoa FOREIGN KEY (id_pessoa_juridica) REFERENCES public.pessoa_juridica(id),
	CONSTRAINT fk_ramo_juridica_ramo FOREIGN KEY (id_ramo) REFERENCES public.ramo(id)
);