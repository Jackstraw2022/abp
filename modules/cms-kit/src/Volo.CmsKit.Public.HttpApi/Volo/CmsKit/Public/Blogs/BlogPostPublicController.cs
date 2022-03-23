﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Users;

namespace Volo.CmsKit.Public.Blogs;

[RequiresGlobalFeature(typeof(BlogsFeature))]
[RemoteService(Name = CmsKitPublicRemoteServiceConsts.RemoteServiceName)]
[Area(CmsKitPublicRemoteServiceConsts.ModuleName)]
[Route("api/cms-kit-public/blog-posts")]
public class BlogPostPublicController : CmsKitPublicControllerBase, IBlogPostPublicAppService
{
    protected IBlogPostPublicAppService BlogPostPublicAppService { get; }

    public BlogPostPublicController(IBlogPostPublicAppService blogPostPublicAppService)
    {
        BlogPostPublicAppService = blogPostPublicAppService;
    }

    [HttpGet]
    [Route("{blogSlug}/{blogPostSlug}")]
    public virtual Task<BlogPostPublicDto> GetAsync(string blogSlug, string blogPostSlug)
    {
        return BlogPostPublicAppService.GetAsync(blogSlug, blogPostSlug);
    }

    [HttpGet]
    [Route("{blogSlug}")]
    public virtual Task<PagedResultDto<BlogPostPublicDto>> GetListAsync(string blogSlug, BlogPostGetListInput input)
    {
        return BlogPostPublicAppService.GetListAsync(blogSlug, input);
    }

    [HttpGet]
    public virtual Task<List<CmsUserDto>> GetAuthorsHasBlogPostsAsync()
    {
        return BlogPostPublicAppService.GetAuthorsHasBlogPostsAsync();
    }
}